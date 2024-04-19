using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MovePool : MonoBehaviour
{
    BattleSystem battleSystem;
    public Creature_SO attacker;
    public Creature_SO defender;
    public static MovePool instance;
    [SerializeField] Button Testbutton;
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

    public void HungeringScream()
    {
        battleSystem.ChangeAttacker();
        defender.DefenceDrop += 1;
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
                button.onClick.AddListener(HungeringScream);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Hungering Scream";
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
            int _temporaryDefence = (BattleSystem.instance.attacker.defence * 100) / (2 * BattleSystem.instance.attacker.DefenceDrop);
            return _temporaryDefence;
        }
    }

    public int CheckTemporaryDefenceDefender()
    {
        if (BattleSystem.instance.attacker.DefenceDrop == 0) return battleSystem.defender.defence;
        else
        {
            int _temporaryDefence = (BattleSystem.instance.defender.defence * 100) / (2 * BattleSystem.instance.defender.DefenceDrop);
            return _temporaryDefence;
        }

    }

    public int CheckTemporaryAttackDefender()
    {
        if (BattleSystem.instance.defender.AttackDrop == 0) return battleSystem.defender.attack;
        else
        {
            int _temporaryDefence = (BattleSystem.instance.defender.attack * 100) / (2 * BattleSystem.instance.defender.AttackDrop);
            return _temporaryDefence;
        }
    }

    public int CheckTemporaryAttackAttacker()
    {
        if (BattleSystem.instance.attacker.AttackDrop == 0) return battleSystem.attacker.attack;
        else
        {
            int _temporaryDefence = (BattleSystem.instance.attacker.attack * 100) / (2 * BattleSystem.instance.attacker.AttackDrop);
            return _temporaryDefence;
        }
    }

}
