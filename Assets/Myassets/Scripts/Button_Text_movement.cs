using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_Text_movement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Vector3 startPosition;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject pivot;
    [SerializeField] AudioClip audioClipStart;
    [SerializeField] AudioClip audioClipEnd;
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        startPosition = text.transform.localPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        text.transform.position = pivot.transform.position;
        AudioManager.instance.PlaySound(audioClipStart);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        text.transform.localPosition = startPosition;
        AudioManager.instance.PlaySound(audioClipEnd);
    }
}
