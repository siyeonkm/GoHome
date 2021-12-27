﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingScript : MonoBehaviour
{
    public GameObject settingImg;
    public static int bgmOnOff = 1;

    // Start is called before the first frame update
    void Start()
    {
        settingImg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSetting() //일시정지
    {
        settingImg.SetActive(true);
    }

    public void OnClickBGMOn()
    {
        bgmOnOff = 1;
    }

    public void OnClickBGMOff()
    {
        bgmOnOff = 0;
    }

    public void OnClickStage()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void OnClickGameContinue() //이어하기
    {
        settingImg.SetActive(false);
    }

    public void OnClickOver() //이어하기
    {
        SceneManager.LoadScene("StartScene");
    }
}
