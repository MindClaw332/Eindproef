using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Movement : MonoBehaviour
{
    [SerializeField] float offset = 0.5f;
    [SerializeField] float speed = 1f;
    float _currentPosition;
    Vector2 _targetPosition;
    void Start()
    {
        _currentPosition = transform.position.y;
        Destroy(this.gameObject, 1.5f);

    }

    void Update()
    {
        transform.position = transform.position + new Vector3(0f, transform.position.y + offset, 0f) * speed * Time.deltaTime;
    }

}
