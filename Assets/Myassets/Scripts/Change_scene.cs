using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_scene : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Scene_Manager.instance.TurnOffUI();
            Scene_Manager.instance.LoadScene(3);
        }
    }
}
