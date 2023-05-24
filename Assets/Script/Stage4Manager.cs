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
            DiaText.GetComponentInChildren<Text>().text = "축하해! 모든 크리스털을 모았구나!";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "2층으로 올라가는 문이 열렸을 거야!";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "얼른 가보자!!";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = " ";
            last1end = true;
        }
        
        else if(last1end == true && last2 == false)
        {
            last2 = true;
            yield return new WaitForSeconds(20f);
            DiaText.GetComponentInChildren<Text>().text = "크리스털 모으느라 고생 많았어";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "어땠어? 네가 어떤 사람인지 좀 알 거 같아?";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "아직 잘 모르겠다고? 하하, 그래도 괜찮아.";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "잘 모르겠더라도 네가 무엇이든 하고자 한다면,";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "너는 무엇이든 할 수 있고, 될 수 있을 거야.";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "이제 현실로 돌아갈 시간이야.";
            yield return new WaitForSeconds(dtime);
            DiaText.GetComponentInChildren<Text>().text = "다시 만나서 반가웠어!";
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
