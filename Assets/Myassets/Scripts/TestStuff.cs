using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TestStuff : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool buttonPressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        print("hier werkt ie");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("hier werkt ie maar omhoog");
    }
}
