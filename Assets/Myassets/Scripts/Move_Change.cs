using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Move_Change : MonoBehaviour
{
    [SerializeField] Button[] moveButtons;
    [SerializeField] Button currentButton;
    [SerializeField] GameObject container;

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
        //button.GetComponentInChildren<TextMeshProUGUI>().autoSizeTextContainer = true;
        switch (_moveID)
        {
            case 0:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Small Attack" + "\n" + "Cost: 60";
                break;
            case 1:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Attack" + "\n" + " Cost: 210";
                break;
            case 2:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Big Attack" + "\n" + "Cost: 420";
                break;
            case 3:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Small Smash" + "\n" + "Cost: 60";
                break;
            case 4:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Shield Smash" + "\n" + "Cost: 210";
                break;
            case 5:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Big Smash" + "\n" + "Cost: 420";
                break;

            case 6:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Colossal Attack" + "\n" + "Cost: 640";
                break;

            case 7:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Colossal Smash" + "\n" + "Cost: 640";
                break;

            case 8:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Hungering Scream" + "\n" + "Cost: 150";
                break;
            case 9:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Intimidation Tactic" + "\n" + "Cost: 150";
                break;
            case 10:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Hungering Bellow" + "\n" + "Cost: 380";
                break;
            case 11:
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Extortion" + "\n" + "Cost: 380";
                break;
            default:
                break;
        }
    }

    public void ChangeMove(int _moveID, int _price)
    {
        if (Creature_Manager.instance.moves.Contains(_moveID) == false && Game_Manager.instance.GetMoney() >= _price)
        {
            Game_Manager.instance.AddMoney(-_price);
            int _index = Creature_Manager.instance.moves.IndexOf(currentButton.GetComponent<MoveOnButton>().moveID);
            Creature_Manager.instance.moves[_index] = _moveID;
            AddMove(_moveID, currentButton);
            DrawButtons();
            Creature_Manager.instance.UpdateUi.Invoke();
            container.SetActive(false);
            print("hier werkt ie");
        }
    }

    public void SelectButton(Button _button)
    {
        currentButton = _button;
    }
}
