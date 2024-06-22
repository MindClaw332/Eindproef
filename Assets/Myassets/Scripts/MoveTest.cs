using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveUpDown : MonoBehaviour
{
    public GameObject targetPivot;
    //public Vector2 targetPosition;
    public float duration = 1f; // Duration of the movement

    //private Vector3 originalPosition; // Store the original position

    void Start()
    {
        // Store the original position at the start
        //originalPosition = transform.position;
        Vector2 _targetPosition = new Vector2(targetPivot.transform.position.x, targetPivot.transform.position.y);

        // Move to the target position
        transform.DOMove(_targetPosition, duration);
    }
}