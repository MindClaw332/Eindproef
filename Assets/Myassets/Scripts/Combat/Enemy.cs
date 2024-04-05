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
    }


    void Start()
    {
        OnEnemyInit.Invoke();
    }

    void Update()
    {

    }

    private int SelectEnemyCreature()
    {
        int creatureIndex;
        print("hier werkt ie");
        print(creatureManager.currentCreature.evolutionStage);
        switch (creatureManager.currentCreature.evolutionStage)
        {
            case 1:
                creatureIndex = Random.Range(1, 3);
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

    public void SetEnemy(Creature_SO _creature)
    {
        var clone = Instantiate(_creature);
        enemyCreature = clone;
    }
}
