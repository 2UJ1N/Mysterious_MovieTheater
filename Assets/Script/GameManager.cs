using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class GameManager : MonoBehaviour
{
    public bool buttonOn;

    public int whichStage;
    public int count;
    public Text Scripts;
    public Text WrongText;
    public Text CorrectText;

    private int[] ans1 = new int[2];
    private int[] ans2 = new int[3];
    private int[] ans3 = new int[4];
    private int[] ans4 = new int[5];
    private int[] ans5 = new int[4];

    private int[] PlayerAns = new int[5];

    StageManager stageManager;

    private void Start()
    {
        stageManager = FindObjectOfType<StageManager>();

        whichStage = 0;
        count = 0;

        // 빨강1 파랑2 노랑3 보라4 초록5
        ans1[0] = 4; ans1[1] = 3;
        ans2[0] = 3; ans2[1] = 4; ans2[2] = 3;
        ans3[0] = 4; ans3[1] = 3; ans3[2] = 5; ans3[3] = 2;
        ans4[0] = 2; ans4[1] = 4; ans4[2] = 1; ans4[3] = 4; ans4[4] = 2;
        ans5[0] = 1; ans5[1] = 4; ans5[2] = 2; ans5[3] = 2;
    }

    private void Update()
    {
    }
    
    public void PushButton(string name)
    {
        switch (whichStage)
        {
            case 1:
                PlayerAns[count - 1] = Convert.ToInt32(name);
                if (ans1.Length == count)
                {
                    buttonOn = false;
                    CheckAns();
                }
                break;
            case 2:
                PlayerAns[count - 1] = Convert.ToInt32(name);
                if (ans2.Length == count)
                {
                    buttonOn = false;
                    CheckAns();
                }
                break;
            case 3:
                PlayerAns[count - 1] = Convert.ToInt32(name);
                if (ans3.Length == count)
                {
                    buttonOn = false;
                    CheckAns();
                }
                break;
            case 4:
                PlayerAns[count - 1] = Convert.ToInt32(name);
                if (ans4.Length == count)
                {
                    buttonOn = false;
                    CheckAns();
                }
                break;
            case 5:
                PlayerAns[count - 1] = Convert.ToInt32(name);
                if (ans5.Length == count)
                {
                    buttonOn = false;
                    CheckAns();
                }
                break;
        }
    }

    public void CheckAns()
    {
        count = 0;
        bool Correct = true;

        switch (whichStage)
        {
            case 1:
                for(int i=0; i<ans1.Length; i++)
                {
                    if (ans1[i] != PlayerAns[i])
                        Correct = false;
                }
                if (!Correct)
                {
                    WrongText.gameObject.SetActive(true);
                    stageManager.StartCoroutine("Wrong");
                }
                else
                {
                    CorrectText.gameObject.SetActive(true);
                    stageManager.StartCoroutine("Stage1Clear");
                }
                break;

            case 2:
                for (int i = 0; i < ans2.Length; i++)
                {
                    if (ans2[i] != PlayerAns[i])
                        Correct = false;
                }
                if (!Correct)
                {
                    WrongText.gameObject.SetActive(true);
                    stageManager.StartCoroutine("Wrong");
                }
                else
                {
                    CorrectText.gameObject.SetActive(true);
                    stageManager.StartCoroutine("Stage2Clear");
                }
                break;

            case 3:
                for (int i = 0; i < ans3.Length; i++)
                {
                    if (ans3[i] != PlayerAns[i])
                        Correct = false;
                }
                if (!Correct)
                {
                    WrongText.gameObject.SetActive(true);
                    stageManager.StartCoroutine("Wrong");
                }
                else
                {
                    CorrectText.gameObject.SetActive(true);
                    stageManager.StartCoroutine("Stage3Clear");
                }
                break;

            case 4:
                for (int i = 0; i < ans4.Length; i++)
                {
                    if (ans4[i] != PlayerAns[i])
                        Correct = false;
                }
                if (!Correct)
                {
                    WrongText.gameObject.SetActive(true);
                    stageManager.StartCoroutine("Wrong");
                }
                else
                {
                    CorrectText.gameObject.SetActive(true);
                    stageManager.StartCoroutine("Stage4Clear");
                }
                break;

            case 5:
                for (int i = 0; i < ans5.Length; i++)
                {
                    if (ans5[i] != PlayerAns[i])
                        Correct = false;
                }
                if (!Correct)
                {
                    WrongText.gameObject.SetActive(true);
                    stageManager.StartCoroutine("Wrong");
                }
                else
                {
                    CorrectText.gameObject.SetActive(true);
                    stageManager.StartCoroutine("Stage5Clear");
                }
                break;
        }
    }
}