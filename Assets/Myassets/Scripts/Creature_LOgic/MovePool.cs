using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MovePool : MonoBehaviour
{
    BattleSystem battleSystem;
    public Creature_SO attacker;
    public Creature_SO defender;
    public static MovePool instance;
    [SerializeField] Button Testbutton;
    public List<int> tier1Moves = new List<int>();
    public List<int> tier2Moves = new List<int>();
    public List<int> tier3Moves = new List<int>();
    public List<int> tier4Moves = new List<int>();
    public List<int> tier5Moves = new List<int>();
    public List<int> tier6Moves = new List<int>();

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

        battleSystem = GetComponent<BattleSystem>();

    }

    void OnEnable()
    {
        tier1Moves.Add(0);
        tier1Moves.Add(3);
        tier1Moves.Add(8);
        tier1Moves.Add(9);

        tier2Moves.Add(1);
        tier2Moves.Add(4);
        tier2Moves.Add(8);
        tier2Moves.Add(9);

        tier3Moves.Add(2);
        tier3Moves.Add(5);
        tier3Moves.Add(8);
        tier3Moves.Add(9);

        tier4Moves.Add(6);
        tier4Moves.Add(7);
        tier4Moves.Add(10);
        tier4Moves.Add(11);
    }

    public void SmallAttack()
    {
        battleSystem.ChangeAttacker();
        int attackerAttack = CheckTemporaryAttackAttacker();
        int defenderDefence = CheckTemporaryDefenceDefender();
        int _damage = 3;
        int effectiveDamage = (_damage * (attackerAttack / 3)) - defenderDefence / 3;
        if (effectiveDamage < 0) effectiveDamage = 0;
        battleSystem.defender.currentHealth -= effectiveDamage;
        battleSystem.combatUI.UpdateUI();
        battleSystem.SwitchTurn();
    }

    public void SmallSmash()
    {
        battleSystem.ChangeAttacker();
        int _damage = 3;
        int attackerAttack = CheckTemporaryDefenceAttacker();
        int defenderDefence = CheckTemporaryDefenceDefender();
        int effectiveDamage = (_damage * (attackerAttack / 3)) - defenderDefence / 3;
        if (effectiveDamage < 0) effectiveDamage = 0;
        battleSystem.defender.currentHealth -= effectiveDamage;
        battleSystem.combatUI.UpdateUI();
        battleSystem.SwitchTurn();
    }

    public void Attack()
    {
        int _damage = 5;
        battleSystem.ChangeAttacker();
        int attackerAttack = CheckTemporaryAttackAttacker();
        int defenderDefence = CheckTemporaryDefenceDefender();
        int effectiveDamage = (_damage * (attackerAttack / 3)) - defenderDefence / 3;
        if (effectiveDamage < 0) effectiveDamage = 0;
        battleSystem.defender.currentHealth -= effectiveDamage;
        battleSystem.combatUI.UpdateUI();
        battleSystem.SwitchTurn();
    }

    public void ShieldSmash()
    {
        int _damage = 5;
        battleSystem.ChangeAttacker();
        int attackerAttack = CheckTemporaryAttackAttacker();
        int defenderDefence = CheckTemporaryDefenceDefender();
        int effectiveDamage = (_damage * attackerAttack / 3) - defenderDefence / 3;
        if (effectiveDamage < 0) effectiveDamage = 0;
        battleSystem.defender.currentHealth -= effectiveDamage;
        battleSystem.combatUI.UpdateUI();
        battleSystem.SwitchTurn();
    }

    public void BigAttack()
    {
        int _damage = 10;
        battleSystem.ChangeAttacker();
        int attackerAttack = CheckTemporaryAttackAttacker();
        int defenderDefence = CheckTemporaryDefenceDefender();
        int effectiveDamage = (_damage * (attackerAttack / 3)) - defenderDefence / 3;
        if (effectiveDamage < 0) effectiveDamage = 0;
        battleSystem.defender.currentHealth -= effectiveDamage;
        battleSystem.combatUI.UpdateUI();
        battleSystem.SwitchTurn();
    }

    public void BigSmash()
    {
        battleSystem.ChangeAttacker();
        int attackerAttack = CheckTemporaryDefenceAttacker();
        int defenderDefence = CheckTemporaryDefenceDefender();
        int _damage = 10;
        int effectiveDamage = (_damage * (attackerAttack / 3)) - defenderDefence / 3;
        if (effectiveDamage < 0) effectiveDamage = 0;
        battleSystem.defender.currentHealth -= effectiveDamage;
        battleSystem.combatUI.UpdateUI();
        battleSystem.SwitchTurn();

    }

    public void ColossalAttack()
    {
        int _damage = 15;
        battleSystem.ChangeAttacker();
        int attackerAttack = CheckTemporaryAttackAttacker();
        int defenderDefence = CheckTemporaryDefenceDefender();
        int effectiveDamage = (_damage * (attackerAttack / 3)) - defenderDefence / 3;
        if (effectiveDamage < 0) effectiveDamage = 0;
        battleSystem.defender.currentHealth -= effectiveDamage;
        battleSystem.combatUI.UpdateUI();
        battleSystem.SwitchTurn();
    }

    public void ColossalSmash()
    {
        battleSystem.ChangeAttacker();
        int attackerAttack = CheckTemporaryDefenceAttacker();
        int defenderDefence = CheckTemporaryDefenceDefender();
        int _damage = 15;
        int effectiveDamage = (_damage * (attackerAttack / 3)) - defenderDefence / 3;
        if (effectiveDamage < 0) effectiveDamage = 0;
        battleSystem.defender.currentHealth -= effectiveDamage;
        battleSystem.combatUI.UpdateUI();
        battleSystem.SwitchTurn();

    }

    public void HungeringScream()
    {
        battleSystem.ChangeAttacker();
        battleSystem.defender.DefenceDrop += 1;
        battleSystem.combatUI.UpdateUI();
        battleSystem.SwitchTurn();
    }

    public void IntimidationTactic()
    {
        battleSystem.ChangeAttacker();
        battleSystem.defender.AttackDrop += 1;
        battleSystem.combatUI.UpdateUI();
        battleSystem.SwitchTurn();
    }

    public void HungeringBellow()
    {
        battleSystem.ChangeAttacker();
        battleSystem.defender.DefenceDrop += 2;
        battleSystem.combatUI.UpdateUI();
        battleSystem.SwitchTurn();
    }

    public void Extortion()
    {
        battleSystem.ChangeAttacker();
        battleSystem.defender.AttackDrop += 2;
        battleSystem.combatUI.UpdateUI();
        battleSystem.SwitchTurn();
    }


    public void DEBUGAttack()
    {
        int _damage = 200;
        battleSystem.ChangeAttacker();
        int attackerAttack = CheckTemporaryAttackAttacker();
        int defenderDefence = CheckTemporaryDefenceDefender();
        int effectiveDamage = (_damage * (attackerAttack / 3)) - defenderDefence / 3;
        if (effectiveDamage < 0) effectiveDamage = 0;
        battleSystem.defender.currentHealth -= effectiveDamage;
        battleSystem.combatUI.UpdateUI();
        battleSystem.SwitchTurn();
    }

    public void AddMove(int _moveID, Button button)
    {
        switch (_moveID)
        {
            case 0:
                button.onClick.AddListener(SmallAttack);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Small Attack";
                break;
            case 1:
                button.onClick.AddListener(Attack);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Attack";
                break;
            case 2:
                button.onClick.AddListener(BigAttack);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Big Attack";
                break;
            case 3:
                button.onClick.AddListener(SmallSmash);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Small Smash";
                break;
            case 4:
                button.onClick.AddListener(ShieldSmash);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Shield Smash";
                break;
            case 5:
                button.onClick.AddListener(BigSmash);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Big Smash";
                break;

            case 6:
                button.onClick.AddListener(ColossalAttack);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Colossal Attack";
                break;

            case 7:
                button.onClick.AddListener(ColossalSmash);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Colossal Smash";
                break;

            case 8:
                button.onClick.AddListener(HungeringScream);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Hungering Scream";
                break;
            case 9:
                button.onClick.AddListener(IntimidationTactic);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Intimidation Tactic";
                break;
            case 10:
                button.onClick.AddListener(HungeringBellow);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Hungering Bellow";
                break;
            case 11:
                button.onClick.AddListener(Extortion);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Extortion";
                break;
            default:
                break;
        }
    }

    public int CheckTemporaryDefenceAttacker()
    {
        if (BattleSystem.instance.attacker.DefenceDrop == 0) return battleSystem.attacker.defence;
        else
        {
            float _temporaryDefence = (float)BattleSystem.instance.attacker.defence * (1 - 0.2f * BattleSystem.instance.defender.DefenceDrop);
            int returnDefence = Mathf.FloorToInt(_temporaryDefence);
            return returnDefence;
        }
    }

    public int CheckTemporaryDefenceDefender()
    {
        if (BattleSystem.instance.defender.DefenceDrop == 0) return battleSystem.defender.defence;
        else
        {
            float _temporaryDefence = (float)battleSystem.defender.defence * (1 - 0.2f * BattleSystem.instance.defender.DefenceDrop);
            int returnDefence = Mathf.FloorToInt(_temporaryDefence);
            return returnDefence;
        }

    }

    public int CheckTemporaryAttackDefender()
    {
        if (BattleSystem.instance.defender.AttackDrop == 0) return battleSystem.defender.attack;
        else
        {
            float _temporaryAttack = (float)BattleSystem.instance.defender.attack * (1 - 0.2f * BattleSystem.instance.defender.AttackDrop);
            int returnAttack = Mathf.FloorToInt(_temporaryAttack);
            return returnAttack;
        }
    }

    public int CheckTemporaryAttackAttacker()
    {
        if (BattleSystem.instance.attacker.AttackDrop == 0) return battleSystem.attacker.attack;
        else
        {
            float _temporaryAttack = (float)BattleSystem.instance.attacker.attack * (1 - 0.2f * BattleSystem.instance.attacker.AttackDrop);
            int returnAttack = Mathf.FloorToInt(_temporaryAttack);
            return returnAttack;
        }
    }

    public void SelectMove(int _moveID)
    {
        switch (_moveID)
        {
            case 0:
                MovePool.instance.SmallAttack();
                print("enemy did Small Attack");
                break;
            case 1:
                MovePool.instance.Attack();
                print("enemy did Attack");
                break;
            case 2:
                MovePool.instance.BigAttack();
                print("enemy did Big Attack");
                break;
            case 3:
                MovePool.instance.SmallSmash();
                print("enemy did Small Smash");
                break;
            case 4:
                MovePool.instance.ShieldSmash();
                print("enemy did Shield Smash");
                break;
            case 5:
                MovePool.instance.BigSmash();
                print("enemy did Big Smash");
                break;
            case 6:
                MovePool.instance.ColossalAttack();
                print("enemy did Colossal Attack");
                break;
            case 7:
                MovePool.instance.ColossalSmash();
                print("enemy did Colossal Smash");
                break;
            case 8:
                MovePool.instance.HungeringScream();
                print("enemy did Hungering Scream");
                break;
            case 9:
                MovePool.instance.IntimidationTactic();
                print("enemy did Intimidation Tactic");
                break;
            case 10:
                MovePool.instance.HungeringBellow();
                print("enemy did Hungering Bellow");
                break;
            case 11:
                MovePool.instance.Extortion();
                print("enemy did Extortion");
                break;
            default:
                break;
        }

    }

    public void EnemyAttack()
    {
        int _attackIndex = Random.Range(0, 4);
        switch (battleSystem.enemyCreature.evolutionStage)
        {
            case 1:
                SelectMove(tier1Moves[_attackIndex]);
                break;
            case 2:
                SelectMove(tier2Moves[_attackIndex]);
                break;
            case 3:
                SelectMove(tier3Moves[_attackIndex]);
                break;
            case 4:
                SelectMove(tier4Moves[_attackIndex]);
                break;
            default:
                Debug.Log("no moves");
                break;
        }
    }

}

