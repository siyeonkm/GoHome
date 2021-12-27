using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GametoStartScene : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("StartScene");
    }
}
