using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Creature_Manager : MonoBehaviour
{
    public static Creature_Manager instance;
    public Creature_SO[] possibleCreatures;
    public Creature_SO currentCreature;
    //public Sprite testSprite;
    [SerializeField] Image creatureImage;
    public Inventory inventory;
    [SerializeField] int sourFruitEaten;
    [SerializeField] int sweetFruitEaten;
    [SerializeField] int currentLevel;
    public UnityEvent UpdateUi;
    public List<int> moves;
    [SerializeField] GameObject heartSprite;
    [SerializeField] GameObject attackSprite;
    [SerializeField] GameObject defenceSprite;
    [SerializeField] GameObject raiseSprite;
    [SerializeField] GameObject lowerSprite;
    [SerializeField] GameObject trainPivot;
    [SerializeField] GameObject arrowPivot;


    // instantiates a scriptable object for the current creature
    public void SetCurrentCreature(Creature_SO _creature)
    {
        var clone = Instantiate(_creature);
        currentCreature = clone;
    }



    //singleton pattern
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        SetCurrentCreature(possibleCreatures[0]);
        for (int i = 0; i < 3; i++)
        {
            moves.Add(i);
        }
        //SetEnemy(FindEvolution(SelectEnemyCreature()));
    }

    void Start()
    {
        inventory = Inventory.instance;
        UpdateUi.Invoke();
        creatureImage.sprite = currentCreature.creatureSprite;
    }

    //raises or lowers stats based on the creature's stress level and caps it when at maximum stress
    public void Train()
    {
        int _randomStat = SelectRandomStat(3);
        int _lowerOrRaiseStat = RaiseOrLowerStat(currentCreature.stressLevel);
        if (currentCreature.stressLevel < 5) ChangeStat(_randomStat, _lowerOrRaiseStat);
        TrainingUiPopup(_randomStat, _lowerOrRaiseStat);
        UpdateUi.Invoke();
    }

    // evolves the creature
    public void evolve()
    {
        if (currentCreature.currentLevel % 4 == 0)
        {
            if (currentCreature.evolutionStage < 4) SetCurrentCreature(FindEvolution(DecideEvolution()));
            creatureImage.sprite = currentCreature.creatureSprite;
            UpdateUi.Invoke();
        }
        //if (currentCreature.evolutionStage < 4) SetCurrentCreature(FindEvolution(DecideEvolution()));

    }

    public void LevelUp()
    {
        currentCreature.currentLevel++;
        UpdateUi.Invoke();
    }

    // feeds the creature
    public void Feed(Item_SO _item)
    {
        if (currentCreature.currentHealth >= currentCreature.maxHealth)
        {
            print("" + currentCreature.name + " is already at full health");
            return;
        }

        if (inventory.items.Contains(_item))
        {
            switch (_item.itemTaste)
            {
                case Item_SO.Taste.sour:
                    sourFruitEaten++;
                    break;
                case Item_SO.Taste.sweet:
                    sweetFruitEaten++;
                    break;
            }
            inventory.RemoveItem(_item);
            Debug.Log("item removed");
            Heal();
            UpdateUi.Invoke();
        }
        else
        {
            print("no item found in inventory");
        }

    }

    void Heal()
    {
        int _healamount = currentCreature.maxHealth / 5;
        currentCreature.currentHealth += _healamount;
        if (currentCreature.currentHealth >= currentCreature.maxHealth)
        {
            print("" + currentCreature.name + " is fully healed");
            currentCreature.currentHealth = currentCreature.maxHealth;
        }
        UpdateUi.Invoke();
    }
    //changes stat and stress
    void ChangeStat(int _statID, int _value)
    {
        switch (_statID)
        {
            case 0:
                currentCreature.maxHealth += _value;
                currentCreature.currentHealth += _value;
                currentCreature.stressLevel += 1;
                break;
            case 1:
                currentCreature.attack += _value;
                currentCreature.stressLevel += 1;
                break;
            case 2:
                currentCreature.defence += _value;
                currentCreature.stressLevel += 1;
                break;
            default:
                break;
        }
    }

    //selects a random stat
    int SelectRandomStat(int _amountOfStats)
    {
        int _stat = Random.Range(0, _amountOfStats);
        if (_stat >= _amountOfStats) print("te hoge stat");
        return _stat;

    }

    // decides if the stat should be raised or lowered
    int RaiseOrLowerStat(int _stresslevel)
    {
        int percentRoll = Random.Range(0, 10);
        if (percentRoll <= 8 - _stresslevel)
        {
            return 1;
        }
        else
        {
            return -1;
        }

    }

    // gets creature stat for other scripts so you cant change it from other scripts
    public int getStat(int _statID)
    {
        switch (_statID)
        {
            case 0:
                return currentCreature.maxHealth;
            case 1:
                return currentCreature.attack;
            case 2:
                return currentCreature.defence;
            case 3:
                return currentCreature.stressLevel;
            case 4:
                return currentCreature.currentHealth;
            case 5:
                return currentCreature.evolutionStage;
            default:
                return 0;
        }
    }



    // decides the next evolution for the creature by creating an id
    int DecideEvolution()
    {
        print(currentCreature.evolutionStage);
        switch (currentCreature.evolutionStage)
        {
            case 1:
                if (currentCreature.defence >= currentCreature.attack)
                {
                    print(currentCreature.id + 1);
                    return currentCreature.id + 1;
                }
                else
                {
                    print(currentCreature.id + 2);
                    return currentCreature.id + 2;
                }
            case 2:
                if (sourFruitEaten >= sweetFruitEaten)
                {
                    print(currentCreature.id + 10);
                    return currentCreature.id + 10;
                }
                else
                {
                    print(currentCreature.id + 20);
                    return currentCreature.id + 20;
                }
            case 3:
                if (currentCreature.stressLevel >= 3)
                {
                    print(currentCreature.id + 100);
                    return currentCreature.id + 100;
                }
                else
                {
                    print(currentCreature.id + 200);
                    return currentCreature.id + 200;
                };
            case 4:
                Debug.Log("fully evolved");
                return currentCreature.id;
            default:
                Debug.Log("no evolution stage found");
                return 0;
        }
    }

    // finds the correct evolution for the creature based on the id
    public Creature_SO FindEvolution(int _id)
    {
        Creature_SO _correctEvolution = null;
        for (int i = 0; i < possibleCreatures.Length; i++)
        {
            if (possibleCreatures[i].id == _id)
            {
                _correctEvolution = possibleCreatures[i];
                //print("evolution has been set to " + _correctEvolution.creatureName);
            }
        }
        if (_correctEvolution == null) { Debug.Log("for loop kaput"); }
        return _correctEvolution;
    }

    public void ResetStress()
    {
        currentCreature.stressLevel = 0;
    }

    public void TrainingUiPopup(int _statType, int _raiseOrLower)
    {
        switch (_statType)
        {
            GameObject statClone;
            case 0:
                statClone = Instantiate(heartSprite, trainPivot.transform.position, quaternion.identity);
                break;
            case 1:
                statClone = Instantiate(attackSprite, trainPivot.transform.position, quaternion.identity);
                break;
            case 2:
                statClone = Instantiate(defenceSprite, trainPivot.transform.position, quaternion.identity);
                break;
            default:
                break;
        }
        
        switch (_raiseOrLower)
        {
            case 1:
                Instantiate(raiseSprite, trainPivot.transform.position, quaternion.identity);
                break;
            case -1:
                Instantiate(lowerSprite, trainPivot.transform.position, quaternion.identity);
                break;
            default:
                break;
        }
    }

}