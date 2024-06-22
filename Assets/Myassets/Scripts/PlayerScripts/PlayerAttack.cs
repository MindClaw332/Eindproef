using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject attackSpawn;
    [SerializeField] GameObject attackEffectPrefab;
    [SerializeField] float attackTravelSpeed = 1f;
    [SerializeField] Animator characterAnimator;
    [SerializeField] AnimationClip attackAnimation;
    bool attackOnCooldown = false;

    Vector3 oldPosition;

    [SerializeField] Game_Manager gm;
    void Awake()
    {
        gm = Game_Manager.instance;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && attackOnCooldown == false)
        {
            StartCoroutine(Attack());
        }
    }

    void LateUpdate()
    {
        oldPosition = transform.position;
    }

    IEnumerator Attack()
    {
        StartCoroutine(AnimateAttack());
        GameObject attack;
        yield return new WaitForSeconds(0.2f);
        attack = Instantiate(attackEffectPrefab, attackSpawn.transform.position, Quaternion.identity);
        attack.GetComponent<Rigidbody2D>().velocity = new Vector2(attackTravelSpeed * DirectionAttack() + calculateVelocity().x, 0f);
        attack.transform.localScale = new Vector3(DirectionAttack(), 1f, 1f);
        print("attack velocity" + attack.GetComponent<Rigidbody2D>().velocity);
        Destroy(attack, 0.4f);
    }

    float DirectionAttack()
    {
        if (Game_Manager.instance.GetFlipped() == true)
        {
            return -1f;
        }
        else
            return 1f;
    }

    Vector3 calculateVelocity()
    {
        return (transform.position - oldPosition) / Time.deltaTime;
    }

    IEnumerator AnimateAttack()
    {
        characterAnimator.SetBool("Attack", true);
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackAnimation.length);
        characterAnimator.SetBool("Attack", false);
        attackOnCooldown = false;
    }
}
