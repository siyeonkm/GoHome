using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int click, nowStage;
    GameObject StageManager;
    public Text stagetext;

    // Start is called before the first frame update
    void Start()
    {
        StageManager = GameObject.Find("stageNum");
        nowStage = StageManager.GetComponent<StagetoGameScene>().stageNum;
        Debug.Log(nowStage);
        stagetext.text = "Stage " + nowStage.ToString();
    }

}
