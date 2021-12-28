using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartScript : MonoBehaviour
{
    public Text Count_text;
    public static int restart_num = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickRestart() //일시정지
    {
        restart_num = 1;
        CarVisibleScript.countnum = 0;
        Count_text.text = "0";
    }
}
