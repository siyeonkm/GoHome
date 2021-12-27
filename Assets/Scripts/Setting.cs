using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
        private static Setting setting;

     private void Awake()
    {
        if(setting == null)
        {
            setting = this;
            DontDestroyOnLoad(setting);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
