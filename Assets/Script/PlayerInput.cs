using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Vertical";
    public string rotateAxisName = "Horizontal";

    public float move { get; private set; }
    public float rotate { get; private set; }
    StageManager stageManager;

    private void Start()
    {
        stageManager = FindObjectOfType<StageManager>();
    }
    private void Update()
    {
        if (!stageManager.isGameClear)
        {
            move = Input.GetAxis(moveAxisName);
            rotate = Input.GetAxis(rotateAxisName);
        }
        else
        {
            move = 0;
            rotate = 0;
        }
        
    }

}