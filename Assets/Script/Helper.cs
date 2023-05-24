using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    [SerializeField] private GameObject TextPanel;
    
    private bool oneclick = false;
    public HUDManager hudManager;

    // Start is called before the first frame update
    void Start()
    {
        TextPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Dialogue.isfinish == true)
        {
            TextPanel.SetActive(false);
            NextLevel();
        }
    }

    private void NextLevel()
    {
        if(oneclick==false)
        {
            hudManager.nextStage();
            oneclick = true;
        }
    }   
}
