using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Feed_Button_Script : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI sourText;
    [SerializeField] TextMeshProUGUI sweetText;
    [SerializeField] GameObject container;
    [SerializeField] Inventory inventory;
    [SerializeField] Item_SO sourFruit;
    [SerializeField] Item_SO sweetFruit;

    [SerializeField] bool turnedOn = false;

    void Start()
    {
        inventory = Inventory.instance;
    }

    public void OpenMenu()
    {
        turnedOn = !turnedOn;
        container.gameObject.SetActive(turnedOn);
    }

    public void UpdateFeedUI()
    {
        sourText.SetText("X " + inventory.GetAmount(sourFruit));
        sweetText.SetText("X " + inventory.GetAmount(sweetFruit));
    }
}
