using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Creature", menuName = "ScriptableObjects/Creature", order = 2)]

public class Creature_SO : ScriptableObject
{
    public string creatureName = "Creature";
    public int id = 000;
    public int evolutionStage = 0;
    public int currentHealth = 5;
    public int maxHealth = 5;
    public int attack = 5;
    public int defence = 5;

    public int stressLevel = 0;
    public int maxStressLevel = 5;

    public int sourFruitEaten = 0;
    public int sweetFruitEaten = 0;

    public int currentLevel = 0;

    public Sprite creatureSprite;
}
