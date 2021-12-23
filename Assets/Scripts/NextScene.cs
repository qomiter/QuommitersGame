using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeAfter2SecondsCoroutine());
    }




    IEnumerator ChangeAfter2SecondsCoroutine()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}