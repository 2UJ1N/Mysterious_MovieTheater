using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{

    public bool isGamePlay;
    public bool isGameClear;
    public GameObject CatIcon;
    public GameObject CharacterIcon;
    GameManager gameManager;

    public GameObject Core1;
    public GameObject Core2;
    public GameObject Core3;
    public GameObject Core4;
    public GameObject Core5;

    public GameObject CS1_1;
    public GameObject CS1_2;
    public GameObject CS2_1;
    public GameObject CS2_2;
    public GameObject CS2_3;
    public GameObject CS3_1;
    public GameObject CS3_2;
    public GameObject CS4_1;
    public GameObject CS4_2;
    public GameObject CS4_3;
    public GameObject CS5_1;
    public GameObject CS5_2;

    public Text Scripts; // 대화 스크립트
    public Text StartText;

    public GameObject Lighting;
    public GameObject MainCamera;
    public GameObject TL1;
    public GameObject Fade;

    void Start()
    {
        isGameClear = false;
        gameManager = FindObjectOfType<GameManager>();

        // 마우스 커서 비활성화
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGamePlay)
        {
            switch (gameManager.whichStage)
            {
                case 0:
                    StartCoroutine("Tutorial");
                    break;
                case 1:
                    StartCoroutine("Stage1");
                    break;
                case 2:
                    StartCoroutine("Stage2");
                    break;
                case 3:
                    StartCoroutine("Stage3");
                    break;
                case 4:
                    StartCoroutine("Stage4");
                    break;
                case 5:
                    StartCoroutine("Stage5");
                    break;
            }
        }
    }


    IEnumerator Tutorial()
    {
        isGamePlay = true;
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(true);
        Scripts.gameObject.SetActive(true);

        Scripts.text = "…여긴 어디지?";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "어디서 본 것 같은 곳인데…";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        CatIcon.SetActive(true);

        Scripts.text = "여긴 영화 속이야.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "너는 방금 포스터를 통해 영화 속으로 들어온 거고.";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        CharacterIcon.SetActive(true);

        Scripts.text = "여기서 나가려면 어떻게 해야 해?";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        CatIcon.SetActive(true);

        Scripts.text = "여기서 나가려면 이 영화를 원래대로 되돌려야 해.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "잘 생각해 봐, 네가 아는 영화랑은 조금 다르지 않니?";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        CharacterIcon.SetActive(true);

        Scripts.text = "…이것보다는 좀 더 밝은 분위기였던 것 같아.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "그리고… 맨 앞의 저 커다란 구슬들은 뭐지?";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        CatIcon.SetActive(true);

        Scripts.text = "이 영화에 <핵심 기억>이 나오는 거 기억 나?";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "저 구슬들이 바로 핵심 기억이야.";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        CharacterIcon.SetActive(true);

        Scripts.text = "저것들이? 내가 기억하는 핵심 기억은 저렇게 안 생겼는데.";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        CatIcon.SetActive(true);

        Scripts.text = "맞아. 저 핵심 기억들이 다시 본래의 빛을 되찾고,";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "원래대로 돌아와야지만 여기서 나갈 수 있을 거야.";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        CharacterIcon.SetActive(true);

        Scripts.text = "내가 뭘 해야 하는데?";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        CatIcon.SetActive(true);

        Scripts.text = "핵심 기억은 중요한 기억 속의 감정들로 이루어져 있어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "핵심 기억이 빛을 잃었다는 것은 곧,\n기억 속 감정들을 잊어버렸다는 것을 의미하지.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "네가 그 기억 속의 감정을 다시 입력해주면 원래대로 돌아올 거야.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "연령대 별로 총 다섯 개의 핵심 기억이 있어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "첫 번째는 같이 해보자.";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        Scripts.text = "";

        gameManager.whichStage = 1;
        isGamePlay = false;
    }

    IEnumerator Stage1()
    {
        isGamePlay = true;
        StartText.text = "STAGE 1";
        StartText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);

        CS1_1.SetActive(true);
        yield return new WaitForSeconds(4.0f);

        CharacterIcon.SetActive(true);

        Scripts.text = "저건……";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        CatIcon.SetActive(true);

        Scripts.text = "기억 나? 유년기 시절의 네 모습이야.";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        CharacterIcon.SetActive(true);

        Scripts.text = "…기억 나. 저때는 분명 엄마의 병문안을 갔던 때였어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "병원은 처음이었는데, 소란스러워서 무서워했었지…";
        yield return new WaitForSeconds(3.0f);

        Scripts.text = "";
        CharacterIcon.SetActive(false);
        CS1_1.SetActive(false);
        CS1_2.SetActive(true);
        yield return new WaitForSeconds(4.0f);

        CharacterIcon.SetActive(true);

        Scripts.text = "하지만 나한테 굉장히 중요하고 행복한 날이었어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "동생이랑 처음 만난 날이었거든.";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        CatIcon.SetActive(true);

        Scripts.text = "맞아! 이 기억이 네 유년기의 핵심 기억이야.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "앞 판넬의 색깔 버튼이 보이지?";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "네가 떠올린 기억 속의 감정을 순서대로 누르면 돼.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "빨간색은 분노, 파란색은 슬픔, 노란색은 기쁨,\n보라색은 불안함, 초록색은 예민함을 뜻해.";
        yield return new WaitForSeconds(5.0f);

        CS1_2.SetActive(false);
        CatIcon.SetActive(false);
        Scripts.text = "(기억을 보고 떠올린 감정의 순서대로 버튼을 눌러보자.)";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "";

        gameManager.buttonOn = true;
    }

    IEnumerator Stage2()
    {
        isGamePlay = true;
        CS1_2.SetActive(false);
        StartText.text = "STAGE 2";
        StartText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        
        CS2_1.SetActive(true);
        yield return new WaitForSeconds(4.0f);

        CharacterIcon.SetActive(true);

        Scripts.text = "이게 내 아동기의 핵심 기억이구나…";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "다 같이 놀이공원에 놀러갔었지. 뚜렷하게 기억 나.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "난 가족들과 보내는 시간을 정말 좋아하거든.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "취직한 이후로는 너무 바빠서 얼굴 보기도 힘들지만…";
        yield return new WaitForSeconds(3.0f);

        Scripts.text = "";
        CharacterIcon.SetActive(false);
        CS2_1.SetActive(false);
        CS2_2.SetActive(true);
        yield return new WaitForSeconds(4.0f);

        CharacterIcon.SetActive(true);
        Scripts.text = "다른 데 정신이 팔려 하마터면 미아가 될 뻔 했었지.";
        yield return new WaitForSeconds(3.0f);

        Scripts.text = "";
        CharacterIcon.SetActive(false);
        CS2_2.SetActive(false);
        CS2_3.SetActive(true);
        yield return new WaitForSeconds(4.0f);

        CharacterIcon.SetActive(true);
        Scripts.text = "처음 가족을 잃어버렸을 때는 정말 무서웠지만,";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "오히려 그래서 다시 만났을 때의 소중함이 더 컸던 것 같아.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "지금 생각해보니 이것도 추억이네.";
        yield return new WaitForSeconds(3.0f);

        CS2_3.SetActive(false);
        CharacterIcon.SetActive(false);
        Scripts.text = "(기억을 보고 떠올린 감정의 순서대로 버튼을 눌러보자.)";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "";

        gameManager.buttonOn = true;
    }

    IEnumerator Stage3()
    {
        isGamePlay = true;
        CS2_3.SetActive(false);
        StartText.text = "STAGE 3";
        StartText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);

        CS3_1.SetActive(true);
        yield return new WaitForSeconds(4.0f);

        CharacterIcon.SetActive(true);
        Scripts.text = "음……";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "고등학교 3학년 첫 시험의 성적표를 받는 날이었던 것 같아.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "시험을 못 봤기 때문에 엄청 긴장하고 있었어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "의외로 점수가 잘 나와서 내심 기뻐하고 있었는데,";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "";
        CharacterIcon.SetActive(false);

        CS3_1.SetActive(false);
        CS3_2.SetActive(true);
        yield return new WaitForSeconds(4.0f);

        CharacterIcon.SetActive(true);
        Scripts.text = "알고 보니 점수는 후했고, 저런 성적에 일희일비한 나만 바보 됐지.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "다른 사람과 결과를 비교해서는 행복할 수 없겠지만,";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "대학 입시 시스템이란 비교와 경쟁이 필연적이거든.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "공부한 만큼 결과에 나오지 않는 나 자신에게 화가 나기도 하고,";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "지망 대학의 커트라인을 검색해보다가 우는 일도 자주 있었어.";
        yield return new WaitForSeconds(3.0f);

        CS3_2.SetActive(false);
        CharacterIcon.SetActive(false);
        Scripts.text = "(기억을 보고 떠올린 감정의 순서대로 버튼을 눌러보자.)";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "";

        gameManager.buttonOn = true;
    }

    IEnumerator Stage4()
    {
        isGamePlay = true;
        CS3_2.SetActive(false);
        StartText.text = "STAGE 4";
        StartText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);

        CS4_1.SetActive(true);
        yield return new WaitForSeconds(4.0f);

        CharacterIcon.SetActive(true);
        Scripts.text = "이날도 끔찍한 날들 중 하나였지…";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "생활비를 벌어야 하는데 아르바이트 면접은 떨어져서 우울하고,";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "바쁜 와중에 과제는 너무 많아서 항상 마감 직전까지 해야 했어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "";
        CharacterIcon.SetActive(false);

        CS4_1.SetActive(false);
        CS4_2.SetActive(true);
        yield return new WaitForSeconds(4.0f);

        CharacterIcon.SetActive(true);
        Scripts.text = "그날도 시간에 쫓기면서 겨우 과제를 끝내고 제출하려고 했는데,";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "제출해야 하는 서버가 하필 마감 시간에 먹통이 됐었지.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "열심히 공부했던 수업이었기 때문에 더더욱 화가 났어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "";
        CharacterIcon.SetActive(false);

        CS4_2.SetActive(false);
        CS4_3.SetActive(true);
        yield return new WaitForSeconds(4.0f);

        CharacterIcon.SetActive(true);
        Scripts.text = "지푸라기라도 잡는 심정으로 교수님께 연장 제출에 대해 여쭤봤지만,";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "전전긍긍 기다린 끝에 온 답신은 단호한 거절이었지.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "그날도 결국 울면서 잠들었지만…";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "대학에 와서도 줄곧 학점 관리와 취준에 시달렸으니까,";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "오히려 기쁜 마음으로 잠든 날이 드물었던 것 같아…";
        yield return new WaitForSeconds(3.0f);

        CS4_3.SetActive(false);
        CharacterIcon.SetActive(false);
        Scripts.text = "(기억을 보고 떠올린 감정의 순서대로 버튼을 눌러보자.)";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "";

        gameManager.buttonOn = true;
    }

    IEnumerator Stage5()
    {
        isGamePlay = true;
        CS4_3.SetActive(false);
        StartText.text = "STAGE 5";
        StartText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);

        CS5_1.SetActive(true);
        yield return new WaitForSeconds(4.0f);

        CharacterIcon.SetActive(true);
        Scripts.text = "봐, 내가 뭐랬어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "진상 전화에 스트레스는 있는 대로 받고,";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "상사한테는 그것도 처리 못하냐며 혼나서 잘릴까 봐 혼자 불안해하고.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "";
        CharacterIcon.SetActive(false);

        CS5_1.SetActive(false);
        CS5_2.SetActive(true);
        yield return new WaitForSeconds(4.0f);

        CharacterIcon.SetActive(true);
        Scripts.text = "퇴근해도 개인 시간을 가질 여유는 없어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "늦은 저녁을 먹고 씻으면 다음날 출근을 위해 자야 하니까.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "슬프고 우울해도 이젠 눈물도 안 나.";
        yield return new WaitForSeconds(3.0f);

        CS5_2.SetActive(false);
        CharacterIcon.SetActive(false);
        Scripts.text = "(기억을 보고 떠올린 감정의 순서대로 버튼을 눌러보자.)";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "";

        gameManager.buttonOn = true;
    }

    IEnumerator Wrong()
    {
        yield return new WaitForSeconds(3.0f);
        CatIcon.SetActive(true);

        Scripts.text = "괜찮아! 다시 시도해보자.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "빨간색은 분노, 파란색은 슬픔, 노란색은 기쁨,\n보라색은 불안함, 초록색은 예민함을 뜻해.";
        yield return new WaitForSeconds(5.0f);
        Scripts.text = "같은 감정을 연속으로 느꼈을 수도 있어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "기억 속 너의 표정을 잘 보면 도움이 될 거야.";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        Scripts.text = "";
        
        switch (gameManager.whichStage)
        {
            case 1:
                StartCoroutine("Stage1");
                break;
            case 2:
                StartCoroutine("Stage2");
                break;
            case 3:
                StartCoroutine("Stage3");
                break;
            case 4:
                StartCoroutine("Stage4");
                break;
            case 5:
                StartCoroutine("Stage5");
                break;
        }
    }

    IEnumerator Stage1Clear()
    {
        yield return new WaitForSeconds(3.0f);
        Core1.GetComponent<Renderer>().material.color = Color.white;
        
        CatIcon.SetActive(true);

        Scripts.text = "저거 봐, 첫 번째 핵심 기억의 빛이 돌아왔어!";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "어렵지 않지?";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        CharacterIcon.SetActive(true);
        Scripts.text = "응, 할 수 있을 것 같아.";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        CatIcon.SetActive(true);
        Scripts.text = "이 다음은 아동기의 기억이야.";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        Scripts.text = "";

        gameManager.whichStage++;
        isGamePlay = false;
        
    }

    IEnumerator Stage2Clear()
    {
        yield return new WaitForSeconds(3.0f);
        Core2.GetComponent<Renderer>().material.color = Color.white;

        CatIcon.SetActive(true);

        Scripts.text = "잘했어! 두 번째 핵심 기억의 빛도 무사히 돌아왔구나.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "다음은 청소년기의 핵심 기억이야.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "어떤 기억이 나올 것 같아?";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        CharacterIcon.SetActive(true);
        
        Scripts.text = "글쎄… 잘 모르겠어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "청소년기에는 별로 이렇다할 좋은 기억이 없네.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "학업과 대학 입시 때문에 정신 없었으니까.";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        Scripts.text = "";

        gameManager.whichStage++;
        isGamePlay = false;
    }

    IEnumerator Stage3Clear()
    {
        yield return new WaitForSeconds(3.0f);
        Core3.GetComponent<Renderer>().material.color = Color.white;

        CatIcon.SetActive(true);
        Scripts.text = "세 번째 핵심 기억의 빛이 돌아왔어!";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "기분은 괜찮니?";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        CharacterIcon.SetActive(true);

        Scripts.text = "솔직히 별로 안 좋아……";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "내가 생각해봐도 청소년기 이래로 행복했던 기억은 별로 없어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "어차피 다음 핵심 기억들도 불행한 기억일 텐데\n굳이 살펴볼 필요 있을까?";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        CatIcon.SetActive(true);
        Scripts.text = "그래도 나는 네가 끝까지 해줬으면 좋겠어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "불행한 기억을 잊고 묻어두는 것만이 능사는 아닐지도 몰라.";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        CharacterIcon.SetActive(true);
        Scripts.text = "…알았어.";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        Scripts.text = "";

        gameManager.whichStage++;
        isGamePlay = false;
    }

    IEnumerator Stage4Clear()
    {
        yield return new WaitForSeconds(3.0f);
        Core4.GetComponent<Renderer>().material.color = Color.white;

        CatIcon.SetActive(true);

        Scripts.text = "이제 딱 하나 남았어. 끝까지 힘내자!";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "마지막 하나는 가장 최근의 핵심 기억이야.";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        CharacterIcon.SetActive(true);

        Scripts.text = "그러면 굳이 안 봐도 알 것 같아.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "화나거나 슬프거나 불안하거나 셋 중 하나겠지.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "겨우겨우 취직한 후에는 기계적으로 출퇴근만 반복했으니까.";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        Scripts.text = "";

        gameManager.whichStage++;
        isGamePlay = false;
    }

    IEnumerator Stage5Clear()
    {
        yield return new WaitForSeconds(3.0f);
        Core5.GetComponent<Renderer>().material.color = Color.white;

        CatIcon.SetActive(true);

        Scripts.text = "모든 핵심 기억의 빛이 돌아왔어.";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        CharacterIcon.SetActive(true);
        Scripts.text = "이게 대체 무슨 의미가 있었던 거야?";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "그냥 불행했던 과거들을 다시 보는 시간이었잖아.";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        CatIcon.SetActive(true);
        Scripts.text = "안 좋은 기억을 상기시켜서 미안해…";
        yield return new WaitForSeconds(3.0f);
        
        Scripts.text = "네 말대로 사회는 비교와 경쟁이 필연적으로 등장하고,";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "많은 사람들이 그 속에서 지독하게 스트레스 받다가\n자신의 자아를 잃어버리곤 해.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "나는 누구인가, 내가 좋아하는 것은 무엇이며 무엇이 하고 싶은가…";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "그것들을 자발적으로 다시 떠올리기에 모두들 너무 지쳐 있지.";
        yield return new WaitForSeconds(3.0f);

        CatIcon.SetActive(false);
        CharacterIcon.SetActive(true);
        Scripts.text = ".........";
        yield return new WaitForSeconds(3.0f);

        CharacterIcon.SetActive(false);
        CatIcon.SetActive(true);
        Scripts.text = "하지만 사람의 자아를 구성하는 가장 근본적인 것은 기억이야.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "네가 어떤 삶을 살아왔는가가 곧 너를 결정해.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "잃어버린 자아를 되찾기 위해 기억을 되짚는 건 꼭 필요한 과정이었어.";
        yield return new WaitForSeconds(3.0f);

        Scripts.text = "사람의 인생은 절대 불행하다고 정해져 있지 않아.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "무엇을 해야 행복한지 자신조차 알기 어려워서\n그렇게 느끼는 것뿐이야.";
        yield return new WaitForSeconds(3.0f);
        CatIcon.SetActive(false);
        Scripts.text = "";

        Lighting.SetActive(true);
        MainCamera.SetActive(false);
        TL1.SetActive(true);
        isGameClear = true;

        CatIcon.SetActive(true);
        Scripts.text = "네 행복을 가져다주는 것들, 네가 좋아하는 것들을 잘 생각해봐.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "여기는 영화의 안이지만, 이제까지 본 것들은 전부 너의 기억이었지.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "이 영화는 네 삶과도 같고, 네 삶은 마치 영화와도 같아.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "그걸 오래도록 기억했으면 좋겠어.";
        yield return new WaitForSeconds(3.0f);
        Scripts.text = "자, 이제 여기서 나가자!";
        yield return new WaitForSeconds(3.0f);

        Fade.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        PlayerPrefs.SetInt("Clear1", 1);
        SceneManager.LoadScene(6);
    }
}
