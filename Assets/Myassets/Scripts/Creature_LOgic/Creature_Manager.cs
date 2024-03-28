using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Creature_Manager : MonoBehaviour
{
    public static Creature_Manager instance;
    public Creature_SO[] possibleCreatures;
    public Creature_SO currentCreature;
    public Sprite testSprite;
    [SerializeField] Image creatureImage;

    public void SetCurrentCreature(Creature_SO _creature)
    {
        var clone = Instantiate(_creature);
        currentCreature = clone;
    }

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
    }

    void Start()
    {
        SetCurrentCreature(possibleCreatures[0]);
        currentCreature.creatureSprite = testSprite;
        creatureImage.sprite = currentCreature.creatureSprite;
    }

    public void Train()
    {
        if (currentCreature.stressLevel < 5) ChangeStat(SelectRandomStat(3), RaiseOrLowerStat(currentCreature.stressLevel));
    }

    void ChangeStat(int _statID, int _value)
    {
        switch (_statID)
        {
            case 0:
                currentCreature.maxHealth += _value;
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

    int SelectRandomStat(int _amountOfStats)
    {
        return Random.Range(0, _amountOfStats - 1);
    }

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
            default:
                return 0;
        }
    }

    public void evolve()
    {
        SetCurrentCreature(FindEvolution(DecideEvolution()));
    }

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
                if (currentCreature.sourFruitEaten >= currentCreature.sweetFruitEaten)
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

    Creature_SO FindEvolution(int _id)
    {
        Creature_SO _correctEvolution = null;
        for (int i = 0; i < possibleCreatures.Length; i++)
        {
            if (possibleCreatures[i].id == _id)
            {
                _correctEvolution = possibleCreatures[i];
                print("evolution has been set to " + _correctEvolution.creatureName);
            }
        }
        if (_correctEvolution == null) { Debug.Log("for loop kaput"); }
        return _correctEvolution;
    }
}