using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set_Move_To_Button : MonoBehaviour
{

    [SerializeField] int moveID;
    [SerializeField] int price;
    
    void Start()
    {
        Button _button = this.GetComponent<Button>();
        Move_Change _script = transform.root.GetComponentInChildren<Move_Change>();
        this.GetComponent<Button>().onClick.AddListener(() => _script.ChangeMove(moveID, price));
    }
}
