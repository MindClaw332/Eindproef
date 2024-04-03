using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Creature_Manager creatureManager;
    public Creature_SO enemyCreature;

    void Awake()
    {
        creatureManager = creatureManager.GetComponent<Creature_Manager>();
        if (creatureManager == null) print("tis voor morgen");
        var clone = Instantiate(creatureManager.FindEvolution(SelectEnemyCreature()));
        enemyCreature = clone;
        print(enemyCreature.creatureName);
        print(enemyCreature.maxHealth);
        print(enemyCreature.attack);
        print(enemyCreature.defence);
        print(enemyCreature.stressLevel);

    }

    private int SelectEnemyCreature()
    {
        int creatureIndex;
        switch (Creature_Manager.instance.currentCreature.evolutionStage)
        {
            case 1:
                creatureIndex = Random.Range(1, 2);
                return creatureIndex;
            case 2:
                creatureIndex = Random.Range(1, 2);
                return creatureIndex;
            case 3:
                creatureIndex = Random.Range(1, 2) + Random.Range(1, 2) * 10;
                return creatureIndex;
            case 4:
                creatureIndex = Random.Range(1, 2) + Random.Range(1, 2) * 10 + Random.Range(1, 2) * 100;
                return creatureIndex;
            default:
                creatureIndex = 0;
                return creatureIndex;

        }
    }

    public int getStat(int _statID)
    {
        switch (_statID)
        {
            case 0:
                return enemyCreature.maxHealth;
            case 1:
                return enemyCreature.attack;
            case 2:
                return enemyCreature.defence;
            case 3:
                return enemyCreature.stressLevel;
            case 4:
                return enemyCreature.currentHealth;
            default:
                return 0;
        }
    }
    void Start()
    {
        print(enemyCreature.id);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
