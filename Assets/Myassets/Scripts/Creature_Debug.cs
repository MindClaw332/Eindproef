using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Debug : MonoBehaviour
{
    //public Creature_Manager creatureManager;
    [SerializeField] int creatureHP;
    [SerializeField] int creatureAttack;
    [SerializeField] int creatureDefence;
    [SerializeField] int creatureStress;
    [SerializeField] string creatureName;
    [SerializeField] int creatureEvolutionstage;

    void Awake()
    {
        //creatureManager = Creature_Manager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        creatureName = Creature_Manager.instance.currentCreature.creatureName;
        creatureHP = Creature_Manager.instance.getStat(0);
        creatureAttack = Creature_Manager.instance.getStat(1);
        creatureDefence = Creature_Manager.instance.getStat(2);
        creatureStress = Creature_Manager.instance.getStat(3);
        creatureEvolutionstage = Creature_Manager.instance.getStat(5);

    }
}
