using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage4Manager : MonoBehaviour
{
    [SerializeField] private GameObject DiaText;
    [SerializeField] private Dialogue_2 D2;
    [SerializeField] private GameObject PlayerPos;

    public static bool LastScript = false;
    public static bool DoorOpen = false;

    private bool goDialogue = true;
    private int  clearStage = 0;
    private int diaCnt = 0;
    private float delaytime = 2f;

    private int sub1;
    private int sub2;

    private bool last1 = false;
    private bool last1end = false;
    private bool last2 = false;


    // Start is called before the first frame update
    void Start()
    {
        SetPlayerPrefs();
        Debug.Log("clear: " + sub1 + "/" + sub2 + "/" + clearStage);
        Debug.Log("item: " + PlayerPrefs.GetInt("Clear1") + "/"+ PlayerPrefs.GetInt("Clear2"));

        DiaText.SetActive(true);
        StartCoroutine("NextScript", delaytime);

        if (sub1 == 1 && sub2 != 1)
            PlayerPos.transform.position = new Vector3(23f, 0f, 31f);

        else if (sub2 == 1 && sub1 == 1)
        {
            PlayerPos.transform.position = new Vector3(0f, 0f, -12f);
            PlayerPos.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));

            clearStage = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (clearStage == 1 && last1 == false)
        {
            //last1 = true;
            DiaText.SetActive(true);
            StartCoroutine("PrintLastScript", delaytime);
        }
        
        if (last2 ==false && last1 == true)
        {
            DiaText.SetActive(true);
            StartCoroutine("PrintLastScript", delaytime);
        }
    }

    void PrintScript()
    {
        if(goDialogue==true)
        {
            DiaText.SetActive(true);
            D2.NextDialogue();
            diaCnt++;

            Debug.Log(diaCnt);

            if (diaCnt == 5 || diaCnt >= 7)
            {
                Debug.Log("STOP");
                DiaText.SetActive(false);
                goDialogue = false;
                PlayerPrefs.SetInt("DialogueCnt", diaCnt);

                if(sub1 == 1 && sub2==0 && clearStage == 0)
                    PlayerPrefs.SetInt("DialogueCnt", 6);
            }
        }
    }
    
    IEnumerator NextScript(float dtime)
    {
        yield return new WaitForSeconds(dtime);
        PrintScript();

        if (goDialogue == true)
            StartCoroutine("NextScript", dtime);
    }

    IEnumerator PrintLastScript(float dtime)
    {
        if(last1 == false)
        {
            last1 = true;
            yield return new WaitForSeconds(5f);
            DiaText.GetComponentInChildren<Text>().text = "������! ��� ũ�������� ��ұ���!";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "2������ �ö󰡴� ���� ������ �ž�!";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "�� ������!!";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = " ";
            last1end = true;
        }
        
        else if(last1end == true && last2 == false)
        {
            last2 = true;
            yield return new WaitForSeconds(20f);
            DiaText.GetComponentInChildren<Text>().text = "ũ������ �������� ��� ���Ҿ�";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "���? �װ� � ������� �� �� �� ����?";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "���� �� �𸣰ڴٰ�? ����, �׷��� ������.";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "�� �𸣰ڴ��� �װ� �����̵� �ϰ��� �Ѵٸ�,";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "�ʴ� �����̵� �� �� �ְ�, �� �� ���� �ž�.";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "���� ���Ƿ� ���ư� �ð��̾�.";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "�ٽ� ������ �ݰ�����!";
            yield return new WaitForSeconds(dtime);
            DiaText.SetActive(false);
        }
    }



    public void NextStage(int stage)
    {
        if(stage == 2)
        {
            if (sub1 == 0)
            {
                PlayerPrefs.SetInt("Clear1", 1);
                PlayerPrefs.SetInt("Sub1Clear", 1);
                SceneManager.LoadScene(stage);
            }
        }

        if (stage == 3)
        {
            if (sub2 == 0)
            {
                PlayerPrefs.SetInt("Clear2", 1);
                PlayerPrefs.SetInt("Sub2Clear", 1);
                SceneManager.LoadScene(stage);
            }
        }

        else
            SceneManager.LoadScene(stage);
    }

    private void SetPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Sub1Clear") == false)
            PlayerPrefs.SetInt("Sub1Clear", 0);

        if(PlayerPrefs.HasKey("Sub2Clear") == false)
            PlayerPrefs.SetInt("Sub2Celar", 0);

        sub1 = PlayerPrefs.GetInt("Sub1Clear");
        sub2 = PlayerPrefs.GetInt("Sub2Celar");

        if (PlayerPrefs.HasKey("AllClear") == false)
            PlayerPrefs.SetInt("AllClear", 0);

        if (PlayerPrefs.HasKey("DialogueCnt") == false)
            PlayerPrefs.SetInt("DialogueCnt", 0);

        if (PlayerPrefs.HasKey("Clear1") == false)
            PlayerPrefs.SetInt("Clear1", 0);

        if (PlayerPrefs.HasKey("Clear2") == false)
            PlayerPrefs.SetInt("Clear2", 0);

        clearStage = PlayerPrefs.GetInt("AllClear");
        diaCnt = PlayerPrefs.GetInt("DialogueCnt");
    }

}
