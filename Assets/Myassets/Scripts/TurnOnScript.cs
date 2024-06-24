using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnScript : MonoBehaviour
{
    bool on = false;

    public void TurnOn(GameObject objectToTurnOn)
    {
        objectToTurnOn.SetActive(on = !on);
    }
}
