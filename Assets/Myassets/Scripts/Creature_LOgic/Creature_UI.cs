using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Creature_UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI creatureName;
    [SerializeField] TextMeshProUGUI creatureHp;
    [SerializeField] TextMeshProUGUI creatureLevel;
    [SerializeField] Image creatureImage;
    [SerializeField] Creature_Manager creatureManager;

    // Start is called before the first frame update
    void OnEnable()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUI()
    {
        creatureName.text = creatureManager.currentCreature.creatureName;
        creatureHp.text = creatureManager.currentCreature.currentHealth.ToString() + "/" + creatureManager.currentCreature.maxHealth.ToString();
        creatureLevel.text = "lv. " + creatureManager.currentCreature.currentLevel.ToString();
        creatureImage.sprite = creatureManager.currentCreature.creatureSprite;
    }
}
