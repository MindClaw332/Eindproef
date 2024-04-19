using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public static BattleSystem instance;
    [SerializeField] Creature_Manager creatureManager;
    [SerializeField] Enemy enemy;
    Creature_SO playerCreature;
    Creature_SO enemyCreature;
    public Creature_SO attacker;
    public Creature_SO defender;
    public enum battleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSE };
    public battleState State;
    [SerializeField] TextMeshProUGUI battleText;
    public UnityEvent UpdateUi;
    [SerializeField] Button attackButton;
    [SerializeField] Button doNothingButton;
    public Combat_UI combatUI;

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
        playerCreature = creatureManager.currentCreature;
        attacker = playerCreature;
        defender = enemyCreature;
        TurnOffButtons();
        StartCoroutine(StartBattle());
    }


    IEnumerator StartBattle()
    {
        battleText.SetText("your opponent will be: " + enemyCreature.creatureName);
        yield return new WaitForSeconds(2f);
        //State = battleState.PLAYERTURN;
        StartCoroutine(PlayerTurn());
    }

    IEnumerator PlayerTurn()
    {
        battleText.SetText("Your turn");
        yield return new WaitForSeconds(2f);
        battleText.SetText("Choose your next move: ");
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
        if (State == battleState.WIN)
        {
            battleText.SetText("You won");
            yield return new WaitForSeconds(2f);
            creatureManager.LevelUp();
            creatureManager.currentCreature.DefenceDrop = 0;
            creatureManager.currentCreature.AttackDrop = 0;
            battleText.SetText("You leveled up. Returning to overworld");
            yield return new WaitForSeconds(5f);
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
        MovePool.instance.Attack();
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
        switch (State)
        {
            case battleState.PLAYERTURN:
                attacker = playerCreature;
                defender = enemyCreature;
                TurnOffButtons();
                break;
            case battleState.ENEMYTURN:
                attacker = enemyCreature;
                defender = playerCreature;
                TurnOnButtons();
                break;

        }
    }

    public void SwitchTurn()
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

    void TurnOffButtons()
    {
        for (int i = 0; i < combatUI.playerButtons.Length; i++)
        {
            combatUI.playerButtons[i].interactable = false;
        }
    }

        void TurnOnButtons()
    {
        for (int i = 0; i < combatUI.playerButtons.Length; i++)
        {
            combatUI.playerButtons[i].interactable = true;
        }
    }

}
