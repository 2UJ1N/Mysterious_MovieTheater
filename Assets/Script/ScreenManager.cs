using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("Clear2", 1);
        PlayerPrefs.SetInt("Sub2Celar", 1);
        Debug.Log("clear: " + PlayerPrefs.GetInt("Sub2Celar"));

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RetruntoStage()
    {

        SceneManager.LoadScene(6);
    }

   
}
