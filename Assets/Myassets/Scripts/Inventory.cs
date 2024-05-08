using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<Item_SO> items = new List<Item_SO>();

    [SerializeField] Item_SO[] allPossibleItems;

    #region Singleton
    //setup singleton
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
    #endregion

    void OnEnable()
    {
        foreach (Item_SO item in allPossibleItems)
        {
            item.amount = 0;
        }
    }

    // add item to inventory
    public void AddItem(Item_SO item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            item.amount = 1;
        }
        else if (items.Contains(item))
        {
            item.amount++;
        }
    }

    //remove item from inventory
    public void RemoveItem(Item_SO item)
    {
        if (items.Contains(item))
        {
            item.amount--;
        }
        if (item.amount <= 0)
        {
            items.Remove(item);
        }
    }

    public int GetAmount(Item_SO item)
    {
        int _amount = item.amount;
        return _amount;
    }
    
}
