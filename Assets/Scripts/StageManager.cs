using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour
{
    public StagetoGameScene sc;

    public void OnClickBox()
    {
        string nowbutton = EventSystem.current.currentSelectedGameObject.name;

        if (nowbutton == "stage1")
            sc.stageNum = 1;
        else if (nowbutton == "stage2")
            sc.stageNum = 2;
        else if (nowbutton == "stage3")
            sc.stageNum = 3;
        
        if (sc.stageNum != 0)
            sc.call();
    }
}
