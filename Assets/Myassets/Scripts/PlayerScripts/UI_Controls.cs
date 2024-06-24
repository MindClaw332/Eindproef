using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controls : MonoBehaviour
{
    public UI uiControls;
    [SerializeField] GameObject creatureUI;
    PlayerAttack playerAttackScript;
    Characters_movement characterMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        playerAttackScript = FindObjectOfType<PlayerAttack>();
        characterMovementScript = FindObjectOfType<Characters_movement>();
    }


    void OnOpenUI()
    {
        Debug.Log("Opening UI");
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            creatureUI.SetActive(!creatureUI.activeSelf);
            playerAttackScript = FindObjectOfType<PlayerAttack>();
            characterMovementScript = FindObjectOfType<Characters_movement>();
            playerAttackScript.enabled = !creatureUI.activeSelf;
            characterMovementScript.enabled = !creatureUI.activeSelf;
        }
        


    }
}
