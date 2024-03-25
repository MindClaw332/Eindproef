using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject attackSpawn;
    [SerializeField] GameObject attackEffectPrefab;
    [SerializeField] float attackTravelSpeed = 1f;

    Game_Manager gm;
    void Start()
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

    void Attack()
    {
        GameObject attack;
        attack = Instantiate(attackEffectPrefab, attackSpawn.transform.position, Quaternion.identity);
        print("attack spawned" + attack.GetComponent<Rigidbody2D>());
        attack.GetComponent<Rigidbody2D>().velocity = new Vector2(attackTravelSpeed * DirectionAttack(), 0f);
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
}
