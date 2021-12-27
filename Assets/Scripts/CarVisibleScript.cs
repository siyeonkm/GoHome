using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarVisibleScript : MonoBehaviour
{

    public GameObject[] car_list = new GameObject[16];
    public int stage = 1;

    private static int c_startX = 126;
    private static int c_startY = -60;

    private static int t_startX = 195;
    private static int t_startY = -60;

    private static int oneStep = 126;

    private static int line = 15;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        changeVisibility(stage);
        changePosition(stage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeVisibility(int stage)
    {
        for(int i=0; i<16; i++)
        {
            car_list[i].SetActive(false);
        }

        if(stage == 1)
        {
            for (int i = 0; i <= 3; i++)
            {
                car_list[i].SetActive(true);
            }

            car_list[12].SetActive(true);
            car_list[13].SetActive(true);
            car_list[14].SetActive(true);
            car_list[15].SetActive(true);
        }
        else if (stage ==2)
        {
            for(int i = 0; i <= 9; i++)
            {
                car_list[i].SetActive(true);
            }

            car_list[12].SetActive(true);
            car_list[14].SetActive(true);
            car_list[15].SetActive(true);
        }
        else
        {
            for (int i = 0; i <= 10; i++)
            {
                car_list[i].SetActive(true);
            }

            car_list[12].SetActive(true);
            car_list[15].SetActive(true);
        }
    }

    public void changePosition(int stage)
    {
        if (stage == 1)
        {
            car_list[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(c_startX+oneStep+line, c_startY-(oneStep*2) - line);
            car_list[0].transform.rotation = Quaternion.Euler(0, 0, 90);

            car_list[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(c_startX, c_startY);
            car_list[1].transform.rotation = Quaternion.Euler(0, 0, 90);

            car_list[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(-(c_startY), -(c_startX) - (oneStep * 4) - line*2);
            car_list[2].transform.rotation = Quaternion.Euler(0, 0, 0);

            car_list[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(c_startX + (oneStep * 4) + line * 2, c_startY - (oneStep * 4) - line * 2);
            car_list[3].transform.rotation = Quaternion.Euler(0, 0, 90);

            car_list[12].GetComponent<RectTransform>().anchoredPosition = new Vector2(-(t_startY), -(t_startX) - oneStep - line);
            car_list[12].transform.rotation = Quaternion.Euler(0, 0, 0);

            car_list[13].GetComponent<RectTransform>().anchoredPosition = new Vector2(t_startX + (oneStep * 2) + line, t_startY - (oneStep * 5) - line*(float)2.5);
            car_list[13].transform.rotation = Quaternion.Euler(0, 0, 90);

            car_list[14].GetComponent<RectTransform>().anchoredPosition = new Vector2(-(t_startY) + (oneStep * 3) + line *(float)1.5, -(t_startX) - oneStep - line);
            car_list[14].transform.rotation = Quaternion.Euler(0, 0, 0);

            car_list[15].GetComponent<RectTransform>().anchoredPosition = new Vector2(-(t_startY) + (oneStep * 5) + line * (float)2.5, -(t_startX));
            car_list[15].transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (stage == 2)
        {
            
        }
        else
        {
            for (int i = 0; i <= 10; i++)
            {
                car_list[i].SetActive(true);
            }

            car_list[12].SetActive(true);
            car_list[15].SetActive(true);
        }
    }
}
