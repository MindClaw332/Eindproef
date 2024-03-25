using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows.Speech;

public class Characters_movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    [SerializeField] Game_Manager gm;

    void Awake()
    {
        if (GetComponent<Rigidbody2D>() != null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        else
        {
            Debug.Log("Rigidbody2D not found");
        }

    }

    void FixedUpdate()
    {
        MoveCharacter(GetMovement(speed));
        ChangeDirection();
    }

    void MoveCharacter(Vector2 _movement)
    {
        if (_movement != Vector2.zero) rb.MovePosition(_movement);
    }

    Vector2 GetMovement(float _speed)
    {
        Vector2 _movement = new Vector2(Input.GetAxis("Horizontal") * _speed, Input.GetAxis("Vertical") * _speed) + rb.position;
        return _movement;
    }

    void ChangeDirection()
    {
        if (Input.GetAxis("Horizontal") > 0 && gm.GetFlipped() == true)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Game_Manager.instance.SetFlipped(false);
        }
        else if (Input.GetAxis("Horizontal") < 0 && gm.GetFlipped() == false)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            Game_Manager.instance.SetFlipped(true);
        }
    }

}
