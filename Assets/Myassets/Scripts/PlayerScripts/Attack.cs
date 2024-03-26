using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] int damage = 1;

    void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.GetComponent<I_Hittable>() != null)
        {
            _col.GetComponent<I_Hittable>().GetHit(damage);
        }
    }
}
