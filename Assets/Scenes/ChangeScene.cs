using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
  
    public void ChangeBtn()
    {
        switch (this.gameObject.name)
        {
            case "start_button": //start 버튼 
                SceneManager.LoadScene("stage"); //스테이지 화면으로 이동 
                break;
            case "out_button": //나가기 버튼
                break;



        }



    }



}
