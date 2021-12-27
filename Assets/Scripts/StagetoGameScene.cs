using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagetoGameScene : MonoBehaviour
{
    public int stageNum;
    public GameObject stageNumObject;

    // Start is called before the first frame update
    public void SceneChange()
    {
        SceneManager.LoadScene("GameScene");
        DontDestroyOnLoad(stageNumObject);
    }
}
