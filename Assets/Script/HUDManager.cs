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
            StageInfo.text = "���������� ���� �ɾ��!";

        else
            StageInfo.text = "STAGE1 3���� ũ����Ż�� ã�ƶ�!";      
    }

    public void nextStage()
    {
        SceneManager.LoadScene(6);
    }

}
