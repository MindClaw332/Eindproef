using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Creature_Manager creatureManager;
    public Creature_SO enemyCreature;
    public Combat_UI combatUI;
    [SerializeField] UnityEvent OnEnemyInit;

    void Awake()
    {

        creatureManager = Creature_Manager.instance;
        if (creatureManager == null) Debug.LogError("Creature manager not found");
        SetEnemy(creatureManager.FindEvolution(SelectEnemyCreature()));
        RaiseDifficulty();
    }


    void Start()
    {
        OnEnemyInit.Invoke();
    }

    private int SelectEnemyCreature()
    {
        int creatureIndex;
        print("hier werkt ie");
        print(creatureManager.currentCreature.evolutionStage);
        switch (creatureManager.currentCreature.evolutionStage)
        {
            case 1:
                creatureIndex = 0;
                print(creatureIndex + "random index");
                return creatureIndex;
            case 2:
                creatureIndex = Random.Range(1, 3);
                print(creatureIndex + "random index");
                return creatureIndex;
            case 3:
                creatureIndex = Random.Range(1, 3) + Random.Range(1, 3) * 10;
                print(creatureIndex + "random index");
                return creatureIndex;
            case 4:
                creatureIndex = Random.Range(1, 3) + Random.Range(1, 3) * 10 + Random.Range(1, 3) * 100;
                print(creatureIndex + "random index");
                return creatureIndex;
            default:
                creatureIndex = 0;
                print(creatureIndex + "random index");
                return creatureIndex;

        }
    }

    public void RaiseDifficulty()
    {
        int _amount = Random.Range(1, 4);
        for (int i = 0; i < _amount; i++)
        {
            ChangeStat(SelectRandomStat(3), CalculateStatChange());
            Debug.Log("difficulty raised");
        }

    }

    int SelectRandomStat(int _amountOfStats)
    {
        int _stat = Random.Range(0, _amountOfStats);
        if (_stat >= _amountOfStats) print("te hoge stat");
        return _stat;
    }

    void ChangeStat(int _statID, int _value)
    {
        switch (_statID)
        {
            case 0:
                enemyCreature.maxHealth += _value;
                enemyCreature.currentHealth += _value;
                break;
            case 1:
                enemyCreature.attack += _value;
                break;
            case 2:
                enemyCreature.defence += _value;
                break;
            default:
                break;
        }
    }

    int CalculateStatChange()
    {
        int _change = Random.Range(1, 3) + 2 * creatureManager.currentCreature.evolutionStage;
        return _change;
    }

    public void SetEnemy(Creature_SO _creature)
    {
        var clone = Instantiate(_creature);
        enemyCreature = clone;
    }


}
