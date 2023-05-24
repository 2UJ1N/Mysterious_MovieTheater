using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HUDManager : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Text StageInfo;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TextCahnger();
    }

    private void TextCahnger()
    {
        if(Inventory.isFull == true)
            StageInfo.text = "곰인형에게 말을 걸어보자!";

        else
            StageInfo.text = "STAGE1 3개의 크리스탈을 찾아라!";      
    }

    public void nextStage()
    {
        SceneManager.LoadScene(6);
    }

}
