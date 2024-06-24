using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public static BattleSystem instance;
    [SerializeField] Enemy enemy;
    public Creature_SO playerCreature;
    public Creature_SO enemyCreature;
    public Creature_SO attacker;
    public Creature_SO defender;
    public enum battleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSE };
    public battleState State;
    [SerializeField] TextMeshProUGUI battleText;
    public UnityEvent UpdateUi;
    public Combat_UI combatUI;
    [SerializeField] int moneyAmount = 80;

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
    }


    void Start()
    {
        State = battleState.START;
        enemyCreature = enemy.enemyCreature;
        playerCreature = Creature_Manager.instance.currentCreature;
        attacker = playerCreature;
        defender = enemyCreature;
        TurnOffButtons();
        StartCoroutine(StartBattle());
    }


    IEnumerator StartBattle()
    {
        battleText.SetText("your opponent will be: " + enemyCreature.creatureName);
        yield return new WaitForSeconds(2f);
        State = battleState.PLAYERTURN;
        StartCoroutine(PlayerTurn());
    }

    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(1f);
        battleText.SetText("Your turn");
        yield return new WaitForSeconds(2f);
        battleText.SetText("Choose your next move: ");
        yield return new WaitForSeconds(0.5f);
        State = battleState.PLAYERTURN;
        TurnOnButtons();
    }

    public void DoNothing()
    {
        ChangeAttacker();
        SwitchTurn();
    }

    IEnumerator EndBattle()
    {
        TurnOffButtons();
        if (State == battleState.WIN && enemyCreature.isBoss == false)
        {
            battleText.SetText("You won");
            yield return new WaitForSeconds(2f);
            int _winMoney = moneyAmount + Creature_Manager.instance.currentCreature.evolutionStage * 20;
            Game_Manager.instance.AddMoney(_winMoney);
            battleText.SetText("You earned " + _winMoney + " [%$#@*(^&&^%");
            yield return new WaitForSeconds(2f);
            Creature_Manager.instance.LevelUp();
            Creature_Manager.instance.ResetStress();
            Creature_Manager.instance.evolve();
            Creature_Manager.instance.currentCreature.DefenceDrop = 0;
            Creature_Manager.instance.currentCreature.AttackDrop = 0;
            battleText.SetText("You leveled up. Returning to overworld");
            yield return new WaitForSeconds(3f);
            Scene_Manager.instance.LoadScene(2);
        }
        else if (State == battleState.WIN && enemyCreature.isBoss == true)
        {
            battleText.SetText("You won???");
            yield return new WaitForSeconds(2f);
            Scene_Manager.instance.LoadScene(4);
        }

        else
        {
            battleText.SetText("You lost");
            yield return new WaitForSeconds(2f);
            battleText.SetText("The game will delete itself now, better luck next time!");
            yield return new WaitForSeconds(5f);
            Application.Quit();
        }
    }

    IEnumerator EnemyTurn()
    {
        TurnOffButtons();
        yield return new WaitForSeconds(1f);
        battleText.SetText("Enemy's turn");
        yield return new WaitForSeconds(2f);
        MovePool.instance.EnemyAttack();
    }

    public void Attack(int _damage)
    {
        ChangeAttacker();
        defender.currentHealth -= _damage;
        combatUI.UpdateUI();
        SwitchTurn();
    }

    public void ChangeAttacker()
    {
        TurnOffButtons();
        Debug.Log("changing attacker");
        switch (State)
        {
            case battleState.PLAYERTURN:
                TurnOffButtons();
                attacker = playerCreature;
                defender = enemyCreature;
                //TurnOffButtons();
                break;
            case battleState.ENEMYTURN:
                attacker = enemyCreature;
                defender = playerCreature;
                //TurnOnButtons();
                break;

        }
    }

    public IEnumerator SwitchTurn()
    {
        TurnOffButtons();
        Debug.Log("Switching turn");

        if (defender.currentHealth > 0)
        {
            switch (State)
            {
                case battleState.PLAYERTURN:

                    State = battleState.ENEMYTURN;
                    StartCoroutine(EnemyTurn());

                    break;
                case battleState.ENEMYTURN:
                    State = battleState.PLAYERTURN;
                    StartCoroutine(PlayerTurn());
                    //TurnOnButtons();
                    break;
            }
        }
        else if (defender.currentHealth <= 0)
        {
            switch (State)
            {
                case battleState.PLAYERTURN:
                    State = battleState.WIN;
                    break;
                case battleState.ENEMYTURN:
                    State = battleState.LOSE;
                    break;
            }
            StartCoroutine(EndBattle());
        }
        yield return new WaitForSeconds(0.5f);
    }

    public void TurnOffButtons()
    {
        Debug.Log("turning off buttons");
        for (int i = 0; i < combatUI.playerButtons.Length; i++)
        {
            combatUI.playerButtons[i].GetComponent<Button_Text_movement>().enabled = false;
            combatUI.playerButtons[i].interactable = false;
        }
    }

    void TurnOnButtons()
    {
        Debug.Log("turning on buttons");
        for (int i = 0; i < combatUI.playerButtons.Length; i++)
        {
            combatUI.playerButtons[i].GetComponent<Button_Text_movement>().enabled = true;
            combatUI.playerButtons[i].interactable = true;
        }
    }

    public void ShowText(string _text)
    {
        battleText.SetText(_text);
    }

    public void StartTurnSwitch()
    {
        StartCoroutine(SwitchTurn());
    }

}
