using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWithDelay : MonoBehaviour
{
    [SerializeField] int sceneId = 2;
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(sceneId);
    }
}
