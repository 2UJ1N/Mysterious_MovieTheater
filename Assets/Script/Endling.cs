using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endling : MonoBehaviour
{
    private float delaytime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("NextStage", delaytime);
    }

    IEnumerator NextStage(float dtime)
    {
        yield return new WaitForSeconds(dtime);
        SceneManager.LoadScene(0);
    }
}
