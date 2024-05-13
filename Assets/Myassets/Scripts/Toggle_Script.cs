using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Script : MonoBehaviour
{
    bool benZitAanDeDrugs = false;
    [SerializeField] GameObject objectToToggle;
    [SerializeField] GameObject objectToToggle2;

    public void Toggle()
    {
        objectToToggle.SetActive(!benZitAanDeDrugs);
        objectToToggle2.SetActive(benZitAanDeDrugs);
        benZitAanDeDrugs = !benZitAanDeDrugs;
    }
}
