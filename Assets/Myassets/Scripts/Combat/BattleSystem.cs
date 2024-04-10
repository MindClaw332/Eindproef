using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] Creature_Manager creatureManager;
    [SerializeField] Enemy enemy;
    Creature_SO playerCreature;
    Creature_SO enemyCreature;
    public enum battleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSE };
    public battleState State;
    [SerializeField] TextMeshProUGUI battleText;
    [SerializeField] UnityEvent UpdateUi;
    Creature_SO attacker;
    Creature_SO defender;
    [SerializeField] Button attackButton;
    [SerializeField] Button doNothingButton;
    [SerializeField] Combat_UI combatUI;
    

    void Start()
    {
        State = battleState.START;
        enemyCreature = enemy.enemyCreature;
        playerCreature = creatureManager.currentCreature;
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
        battleText.SetText("Your turn");
        yield return new WaitForSeconds(2f);
        battleText.SetText("Choose your next move: ");
        State = battleState.PLAYERTURN;
    }

    public void Attack(int _damage)
    {

        ChangeAttacker();
        defender.currentHealth -= (_damage * (attacker.attack / 3)) - defender.defence / 3;
        combatUI.UpdateUI();
        SwitchTurn();

    }

    public void DoNothing()
    {
        ChangeAttacker();
        SwitchTurn();
    }

    IEnumerator EndBattle()
    {
        attackButton.interactable = false;
        doNothingButton.interactable = false;
        if (State == battleState.WIN)
        {
            battleText.SetText("You won");
            yield return new WaitForSeconds(2f);
            battleText.SetText("You leveled up. Returning to overworld");
            yield return new WaitForSeconds(2f);
        }
        else
        {
            battleText.SetText("You lost");
            yield return new WaitForSeconds(2f);
            battleText.SetText("Returning to Main Menu, better luck next time!");
            yield return new WaitForSeconds(5f);
        }

    }

    IEnumerator EnemyTurn()
    {
        battleText.SetText("Enemy's turn");
        yield return new WaitForSeconds(2f);
        Attack(10);
    }

    void ChangeAttacker()
    {
        switch (State)
        {
            case battleState.PLAYERTURN:
                attacker = playerCreature;
                defender = enemyCreature;
                attackButton.interactable = true;
                doNothingButton.interactable = true;
                break;
            case battleState.ENEMYTURN:
                attacker = enemyCreature;
                defender = playerCreature;
                attackButton.interactable = false;
                doNothingButton.interactable = false;
                break;

        }
    }

    void SwitchTurn()
    {
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
    }
}
