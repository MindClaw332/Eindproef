using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TestStuff : MonoBehaviour
{

    //[SerializeField] Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(RandomprintTest());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Test(int _print)
    {
        Debug.Log(_print);
    }

    IEnumerator RandomprintTest()
    {
        print(Random.Range(0, 4));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(RandomprintTest());
    }
}
