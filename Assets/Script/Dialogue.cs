using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueText
{
    [TextArea]
    public string dialogue;
}

public class Dialogue : MonoBehaviour
{
    public Text txtD;

    static public bool isfinish = false;

    private int cnt = 0;
    static private string[] dia;

    private void Awake()
    {
        dia = new string[6];

        dia[0] = "내 이름은 디디야. 나를 깨운 게 너구나?";
        dia[1] = "이런 곳에 살아있는 사람이 온건 정말 오랜만이야.";
        dia[2] = "널 만나서 너무 반갑지만 이러고 있을 시간이 없어.";
        dia[3] = "이곳에 계속 있다가는 네 일상으로 돌아갈 수 없을 거야.";
        dia[4] = "네가 이곳을 탈출할 수 있도록 내가 도와줄게!";
        dia[5] = " ";
    }

    private void Start()
    {
        ShowDialogue(cnt);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (cnt < dia.Length)
                NextDialogue();
        }
    }

    public void ShowDialogue(int cnt_)
    {
        cnt = cnt_;
        NextDialogue();
    }

    private void NextDialogue()
    {
        txtD.text = dia[cnt];
        cnt++;

        if (cnt >= dia.Length)
            isfinish = true;
    }

}
