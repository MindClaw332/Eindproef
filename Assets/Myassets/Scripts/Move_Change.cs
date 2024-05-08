using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Move_Change : MonoBehaviour
{
    [SerializeField] Button[] moveButtons;
    [SerializeField] Button currentButton;

    public void OnEnable()
    {
        DrawButtons();
    }

    public void DrawButtons()
    {
        for (int i = 0; i < Creature_Manager.instance.moves.Count; i++)
        {
            AddMove(Creature_Manager.instance.moves[i], moveButtons[i]);
            moveButtons[i].GetComponent<MoveOnButton>().moveID = Creature_Manager.instance.moves[i];
        }
    }

    public void AddMove(int _moveID, Button button)
    {
        switch (_moveID)
        {
            case 0:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Small Attack";
                break;
            case 1:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Attack";
                break;
            case 2:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Big Attack";
                break;
            case 3:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Small Smash";
                break;
            case 4:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Shield Smash";
                break;
            case 5:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Big Smash";
                break;

            case 6:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Colossal Attack";
                break;

            case 7:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Colossal Smash";
                break;

            case 8:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Hungering Scream";
                break;
            case 9:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Intimidation Tactic";
                break;
            case 10:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Hungering Bellow";
                break;
            case 11:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Extortion";
                break;
            default:
                break;
        }
    }
    
    public void ChangeMove(int _moveID, int _price)
    {
        //Creature_Manager.instance.moves.Remove(currentButton.GetComponent<MoveOnButton>().moveID);
        //Creature_Manager.instance.moves.Add(_moveID);
        if (Creature_Manager.instance.moves.Contains(_moveID) == false && Game_Manager.instance.GetMoney() >= _price)
        {
            Game_Manager.instance.AddMoney(-_price);
            int _index = Creature_Manager.instance.moves.IndexOf(currentButton.GetComponent<MoveOnButton>().moveID);
            Creature_Manager.instance.moves[_index] = _moveID;
            AddMove(_moveID, currentButton);
            DrawButtons();
            Creature_Manager.instance.UpdateUi.Invoke();
        }
    }

    public void SelectButton(Button _button)
    {
        currentButton = _button;
    }
}
