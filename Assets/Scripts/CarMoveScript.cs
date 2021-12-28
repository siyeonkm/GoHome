using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CarMoveScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 DefaultPos;
    public static Vector2 DefaultPosLocal;
    public static float RotationPos;
    public bool CollisionExist = false;
    public int cnt = 0;

    public Text count;

    public string colName = "";
    public Vector3 direction;

    public Vector3 dir;

    public Vector2 CurrentPos, PrevPos;

    void Update()
    {
        if (CollisionExist == true && cnt == 0)
        {
            cnt++;
            Debug.LogWarning("충돌");
            Debug.Log(CarVisibleScript.drag_item+" " + this.name);
            if (RotationPos == 90 && CarVisibleScript.drag_item == this.name)
            {
                Vector2 pos = this.GetComponent<RectTransform>().anchoredPosition;
                if (dir.x > 0)
                {
                    this.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x - 126 - 8, pos.y);
                    CarVisibleScript.countnum--;
                }
                else
                {
                    this.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x + 126 + 8, pos.y);
                    CarVisibleScript.countnum--;
                }
            }
            else if (RotationPos != 90 && CarVisibleScript.drag_item == this.name)
            {
                Vector2 pos = this.GetComponent<RectTransform>().anchoredPosition;
                if (dir.y > 0)
                {
                    this.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y - 126 - 8);
                    CarVisibleScript.countnum--;
                }
                else
                {
                    this.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y + 126 + 8);
                    CarVisibleScript.countnum--;
                }
            }
            if (CarVisibleScript.drag_item != this.name) this.transform.position = this.transform.position;
            count.text = CarVisibleScript.countnum.ToString();
            Invoke("Erase", 1.0f);
        }
        
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log(this.name + "transform.position : " + this.transform.position + "\n");
        Debug.Log(this.name + ".GetComponent<RectTransform>().anchoredPosition : " + this.GetComponent<RectTransform>().anchoredPosition);
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        DefaultPos = this.transform.position;
        DefaultPosLocal = this.GetComponent<RectTransform>().anchoredPosition;
        RotationPos = this.GetComponent<RectTransform>().eulerAngles.z;
        CarVisibleScript.changeDragItem(this.name);
        Debug.Log("위치: " + DefaultPos + "    " + "각도: " + RotationPos);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        CurrentPos = eventData.position;

//        if (CollisionExist==true)
//        {
//            this.transform.position = this.transform.position;
//        }

//        if(CollisionExist==false)
//        {
//            if (RotationPos == 90)
//            {
//                Debug.Log("가로 자동차!!!");
//                Vector3 poss = new Vector3(currentPos.x, this.transform.position.y, this.transform.position.z);
 //               this.transform.SetPositionAndRotation(poss, this.transform.rotation);
//                Debug.Log("현재위치: " + this.transform.position);
//            }
//            else
//            {
//                Debug.Log("세로 자동차!!!");
//                Vector3 poss = new Vector3(this.transform.position.x, currentPos.y, this.transform.position.z);
//                this.transform.SetPositionAndRotation(poss, this.transform.rotation);
//                Debug.Log("현재위치: " + this.transform.position);
//            }
//        }
        PrevPos = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = this.transform.position;
        dir = CurrentPos - DefaultPos;
        dir = dir.normalized * 3;
        Debug.Log("dragging :" + dir);
        if(RotationPos == 90)
        {
            Vector2 pos = this.GetComponent<RectTransform>().anchoredPosition;
            if (dir.x > 0 && pos.y == -327 && pos.x + 126 < 796)
            {
                this.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x + 126 + 8, pos.y);
                CarVisibleScript.countnum++;
                count.text = CarVisibleScript.countnum.ToString();
            }
            else if (dir.x > 0 && pos.x + 126 < 662)
            {
                this.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x + 126 + 8, pos.y);
                CarVisibleScript.countnum++;
                count.text = CarVisibleScript.countnum.ToString();
            }
            else if (dir.x < 0 && pos.x - 126 > 125)
            {
                this.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x - 126 - 8, pos.y);
                CarVisibleScript.countnum++;
                count.text = CarVisibleScript.countnum.ToString();
            }
        }
        else
        {
            Vector2 pos = this.GetComponent<RectTransform>().anchoredPosition;
            if (dir.y > 0 && pos.y + 126 < -124)
            {
                this.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y + 126 + 8);
                CarVisibleScript.countnum++;
                count.text = CarVisibleScript.countnum.ToString();
            }
            else if (dir.y < 0 && pos.y - 126 > -655)
            {
                this.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y - 126 - 8);
                CarVisibleScript.countnum++;
                count.text = CarVisibleScript.countnum.ToString();
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D obj)
    {
        CollisionExist = true;
        string name = obj.gameObject.name;
        Debug.LogWarning("충돌물체: " + name);
        if (name == this.name) CollisionExist = false;
    }

    public void OnCollisionExit2D()
    {
        CollisionExist = false;
    }

    public void Erase()
    {
        cnt = 0;
    }




}
