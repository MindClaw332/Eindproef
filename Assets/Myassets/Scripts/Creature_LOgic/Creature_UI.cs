using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Creature_UI : MonoBehaviour
{
    //public static Creature_UI instance;
    [SerializeField] TextMeshProUGUI creatureName;
    [SerializeField] TextMeshProUGUI creatureHp;
    [SerializeField] TextMeshProUGUI creatureLevel;
    [SerializeField] Image creatureImage;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI hpIconText;
    [SerializeField] TextMeshProUGUI AttackIconText;
    [SerializeField] TextMeshProUGUI defenseIconText;
    [SerializeField] TextMeshProUGUI stressText;

    void Awake()
    {
        /*if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);*/
    }

    void OnEnable()
    {
        UpdateUI();
        UpdateStats();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUI()
    {
        creatureName.text = Creature_Manager.instance.currentCreature.creatureName;
        //creatureHp.text = Creature_Manager.instance.currentCreature.currentHealth.ToString() + "/" + Creature_Manager.instance.currentCreature.maxHealth.ToString();
        creatureLevel.text = "lv. " + Creature_Manager.instance.currentCreature.currentLevel.ToString();
        creatureImage.sprite = Creature_Manager.instance.currentCreature.creatureSprite;
        moneyText.text = "X " + Game_Manager.instance.GetMoney().ToString();
    }

    public void UpdateStats()
    {
        hpIconText.text = Creature_Manager.instance.currentCreature.currentHealth.ToString() + "/" + Creature_Manager.instance.currentCreature.maxHealth.ToString();
        AttackIconText.text = Creature_Manager.instance.currentCreature.attack.ToString();
        defenseIconText.text = Creature_Manager.instance.currentCreature.defence.ToString();
        stressText.text = "stress: " + "\n" + Creature_Manager.instance.currentCreature.stressLevel.ToString() + "/ 5";

    }
}
