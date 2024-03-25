using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item_SO : ScriptableObject
{
public string itemName;
public GameObject prefab;
public Sprite sprite;
public int amount;
public enum Taste { sweet, sour };
public Taste itemTaste;
}

