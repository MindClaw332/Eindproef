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
        currentCreature.creatureName = "test";
        currentCreature.creatureSprite = testSprite;
        creatureImage.sprite = currentCreature.creatureSprite;
        Train();
    }

    public void Train()
    {
        if (currentCreature.stressLevel <= 5) ChangeStat(SelectRandomStat(3), RaiseOrLowerStat(currentCreature.stressLevel));
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


}
