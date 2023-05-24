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

        dia[0] = "이곳은 현실과 상상의 경계야!";
        dia[1] = "여기서 나가기 위해서는 두개의 크리스탈이 필요해.";
        dia[2] = "그게 없으면 현실로 돌아갈 수 있는 문이 열리지 않거든.";
        dia[3] = "복도를 돌아다니다 보면 영화 포스터가 있을거야.";
        dia[4] = "일단 포스터를 찾아보자!";
        dia[5] = " ";

        dia[6] = "이게 바로 크리스탈! 얼른 'E' 키를 눌러서 획득하자!";
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
