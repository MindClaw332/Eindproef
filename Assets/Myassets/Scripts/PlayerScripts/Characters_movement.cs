using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows.Speech;

public class Characters_movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    [SerializeField] Animator characterAnimator;
    [SerializeField] AudioSource audioSource;
    //[SerializeField] Game_Manager gm;

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
        //Game_Manager.instance.SetFlipped(false);

    }
    void OnEnable()
    {
        Game_Manager.instance.SetFlipped(false);
    }

    void FixedUpdate()
    {
        MoveCharacter(GetMovement(speed));
        AnimatorSet();
        ChangeDirection();
    }

    void MoveCharacter(Vector2 _movement)
    {
        if (_movement - rb.position != Vector2.zero)
        {
            Debug.Log("moving");
            rb.MovePosition(_movement);
            audioSource.gameObject.SetActive(true);
        }
        else
        {audioSource.gameObject.SetActive(false); Debug.Log("no movement"); }
    }

    Vector2 GetMovement(float _speed)
    {
        Vector2 _movement = new Vector2(Input.GetAxis("Horizontal") * _speed, Input.GetAxis("Vertical") * _speed) + rb.position; ;
        return _movement;
    }

    void ChangeDirection()
    {
        if (Input.GetAxis("Horizontal") > 0 && Game_Manager.instance.GetFlipped() == true)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Game_Manager.instance.SetFlipped(false);
        }
        else if (Input.GetAxis("Horizontal") < 0 && Game_Manager.instance.GetFlipped() == false)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            Game_Manager.instance.SetFlipped(true);
        }
    }

    public void AnimatorSet()
    {
        Vector2 _movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (_movement != Vector2.zero)
        {
            if (Mathf.Abs(_movement.y) > 0)
            {
                characterAnimator.SetFloat("Speed", Mathf.Abs(_movement.y));
            }
            else
            {
                characterAnimator.SetFloat("Speed", Mathf.Abs(_movement.x));
            }
        }
    }

}
