using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageScript : MonoBehaviour
{
    public static int stage = 1;
    public static int currStage;
    public void BackSceneBtn()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnClickStage1() {
        currStage = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickStage2()
    {
        if(stage>=2)
        {
            currStage = 2;
            SceneManager.LoadScene("GameScene");
        }
    }

    public void OnClickStage3()
    {
        if (stage >= 3)
        {
            currStage = 3;
            SceneManager.LoadScene("GameScene");
        }
    }
}
