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

        dia[0] = "�� �̸��� ����. ���� ���� �� �ʱ���?";
        dia[1] = "�̷� ���� ����ִ� ����� �°� ���� �������̾�.";
        dia[2] = "�� ������ �ʹ� �ݰ����� �̷��� ���� �ð��� ����.";
        dia[3] = "�̰��� ��� �ִٰ��� �� �ϻ����� ���ư� �� ���� �ž�.";
        dia[4] = "�װ� �̰��� Ż���� �� �ֵ��� ���� �����ٰ�!";
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
