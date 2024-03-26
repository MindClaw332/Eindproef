using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject attackSpawn;
    [SerializeField] GameObject attackEffectPrefab;
    [SerializeField] float attackTravelSpeed = 1f;

    Vector3 oldPosition;

    Game_Manager gm;
    void Awake()
    {
        gm = Game_Manager.instance;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void LateUpdate()
    {
        oldPosition = transform.position;
    }

    void Attack()
    {
        GameObject attack;
        attack = Instantiate(attackEffectPrefab, attackSpawn.transform.position, Quaternion.identity);
        attack.GetComponent<Rigidbody2D>().velocity = new Vector2(attackTravelSpeed * DirectionAttack() + calculateVelocity().x, 0f);
        attack.transform.localScale = new Vector3(DirectionAttack(), 1f, 1f);
        print("attack velocity" + attack.GetComponent<Rigidbody2D>().velocity);
        Destroy(attack, 0.2f);
    }

    float DirectionAttack()
    {
        if (gm.GetFlipped() == true)
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
}
