using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit_World : MonoBehaviour
{
    [SerializeField] Item_SO fruitItem;

    void Awake()
    {
        if (fruitItem == null)
        {
            Debug.LogError( "item_so not found on " + gameObject.name);
        }
    }
    void OnTriggerEnter2D(Collider2D _col)
    {
        print("collided with " + _col.gameObject.name);
        if (_col.gameObject.tag == "Player")
        {
            Inventory.instance.AddItem(fruitItem);
            Destroy(gameObject);
        }
    }
}
