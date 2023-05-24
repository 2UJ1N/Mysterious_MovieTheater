using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    Renderer buttonColor;
    Color C0;

    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        buttonColor = gameObject.GetComponent<Renderer>();
        C0 = buttonColor.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // 클릭 시 색깔 바뀌었다가
    private void OnMouseDown()
    {
        if (gameManager.buttonOn)
        {
            buttonColor.material.color = Color.white;

            gameManager.count++;
            gameManager.PushButton(gameObject.name);
        }
        
    }
    // 마우스 버튼 놓으면 다시 원래대로
    private void OnMouseUp()
    {
        buttonColor.material.color = C0;
    }
}
