using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomain : MonoBehaviour
{
    public void BackSceneBtn()
    {
        SceneManager.LoadScene("main");
    }
}
