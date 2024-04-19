using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestStuff : MonoBehaviour
{

    [SerializeField] Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Test(int _print)
    {
        Debug.Log(_print);
    }
}
