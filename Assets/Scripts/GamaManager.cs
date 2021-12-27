using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int click, nowStage;
    GameObject StageManager;

    // Start is called before the first frame update
    void Start()
    {
        StageManager = GameObject.Find("stageNum");
        nowStage = StageManager.GetComponent<StagetoGameScene>().stageNum;
    }

}
