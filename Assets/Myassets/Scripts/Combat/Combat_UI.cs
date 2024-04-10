using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Combat_UI : MonoBehaviour
{
    public Creature_Manager creatureManager;
    public Enemy enemy;
    [SerializeField] Image playerImage;
    [SerializeField] Image enemyImage;
    [SerializeField] TextMeshProUGUI playerHealthText;
    [SerializeField] TextMeshProUGUI enemyHealthText;
    [SerializeField] Slider playerHealthSlider;
    [SerializeField] Slider enemyHealthSlider;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUI()
    {
        playerHealthText.text = creatureManager.currentCreature.currentHealth.ToString() + "/" + creatureManager.currentCreature.maxHealth.ToString();
        enemyHealthText.text = enemy.enemyCreature.currentHealth.ToString() + "/" + enemy.enemyCreature.maxHealth.ToString();
        playerHealthSlider.maxValue = creatureManager.currentCreature.maxHealth;
        enemyHealthSlider.maxValue = enemy.enemyCreature.maxHealth;
        playerImage.sprite = creatureManager.currentCreature.creatureSprite;
        enemyImage.sprite = enemy.enemyCreature.creatureSprite;
        
        playerHealthSlider.value = creatureManager.currentCreature.currentHealth;
        enemyHealthSlider.value = enemy.enemyCreature.currentHealth;
    }
}
