using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue_2 : MonoBehaviour
{
    private int sub1;
    private int sub2;
    private int item1;
    private int item2;
    private int all;

    public Text txtD;

    static public bool isfinish = false;

    private int cnt = 0;
    static private string[] dia;

    private void Awake()
    {
        dia = new string[8];

        dia[0] = "�̰��� ���ǰ� ����� ����!";
        dia[1] = "���⼭ ������ ���ؼ��� �ΰ��� ũ����Ż�� �ʿ���.";
        dia[2] = "�װ� ������ ���Ƿ� ���ư� �� �ִ� ���� ������ �ʰŵ�.";
        dia[3] = "������ ���ƴٴϴ� ���� ��ȭ �����Ͱ� �����ž�.";
        dia[4] = "�ϴ� �����͸� ã�ƺ���!";
        dia[5] = " ";

        dia[6] = "�̰� �ٷ� ũ����Ż! �� 'E' Ű�� ������ ȹ������!";
        dia[7] = " ";
    }

    private void Start()
    {
        sub1 = PlayerPrefs.GetInt("Sub1Clear");
        sub2 = PlayerPrefs.GetInt("Sub2Celar");
        all = PlayerPrefs.GetInt("AllClear");
        item1 = PlayerPrefs.GetInt("Clear1");
        item2 = PlayerPrefs.GetInt("Clear2");



        if (item1 == 0 && item2 == 0)
            cnt = 0;

        else //if ((item1 == 1 && item2 == 0)&&(item1 == 2 && item2 ==1))
            cnt = 6;

        ShowDialogue(cnt);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

    public void NextDialogue()
    {
        if(isfinish==false)
        {
            txtD.text = dia[cnt];
            cnt++;

            if (cnt >= dia.Length)
                isfinish = true;
        }
    }

    IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowDialogue(12);
    }

}
