using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public GameObject Carprefab;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.DeleteAll();
        StartCoroutine(TimeUpdate());
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    private IEnumerator TimeUpdate()
    {
        while(true)
        {
            Instantiate(Carprefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(4f);
        }
    }
}
