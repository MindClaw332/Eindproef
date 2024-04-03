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
        //playerImage.sprite = creatureManager.currentCreature.creatureSprite;
        //enemyImage.sprite = enemy.enemyCreature.creatureSprite;
        playerHealthText.SetText(Creature_Manager.instance.currentCreature.currentHealth.ToString() + "/" + Creature_Manager.instance.currentCreature.maxHealth.ToString());
        playerHealthSlider.maxValue = creatureManager.getStat(0);
        playerHealthSlider.value = creatureManager.getStat(4);

        enemyHealthText.SetText(enemy.getStat(4).ToString() + "/" + enemy.getStat(0).ToString());
        enemyHealthSlider.maxValue = enemy.getStat(0);
        enemyHealthSlider.value = enemy.getStat(4);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
