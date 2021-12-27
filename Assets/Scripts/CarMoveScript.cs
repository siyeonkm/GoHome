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
    public bool dragging = false;
    public int cnt = 0;

    public string colName = "";
    public Vector3 direction;

    public Vector2 CurrentPos, PrevPos;

    void Update()
    {
        if (CollisionExist == true && dragging == true)
        {
            Debug.LogWarning("충돌");
            if (direction.x > 0 && RotationPos == 90)
            {
                this.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
                Invoke("Rest", 2.0f);
            }
            else if (direction.x < 0 && RotationPos == 90)
            {
                this.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
                Invoke("Rest", 2.0f);
            }
            else if (direction.y > 0 && RotationPos != 90)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z);
                Invoke("Rest", 2.0f);
            }
            else if (direction.y < 0 && RotationPos != 90)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
                Invoke("Rest", 2.0f);
            }

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
        dragging = true;
        Debug.Log("위치: " + DefaultPos + "    " + "각도: " + RotationPos);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        cnt++;
        if(cnt == 3) CurrentPos = eventData.position;
        if (CollisionExist==true)
        {
            this.transform.position = this.transform.position;
        }

        if(CollisionExist==false)
        {
            if (RotationPos == 90)
            {
                Debug.Log("가로 자동차!!!");
                Vector3 poss = new Vector3(currentPos.x, this.transform.position.y, this.transform.position.z);
                this.transform.SetPositionAndRotation(poss, this.transform.rotation);
                Debug.Log("현재위치: " + this.transform.position);
            }
            else
            {
                Debug.Log("세로 자동차!!!");
                Vector3 poss = new Vector3(this.transform.position.x, currentPos.y, this.transform.position.z);
                this.transform.SetPositionAndRotation(poss, this.transform.rotation);
                Debug.Log("현재위치: " + this.transform.position);
            }
        }
        if (cnt == 1) PrevPos = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = this.transform.position;
        dragging = false;
    }

    public void OnCollisionEnter2D(Collision2D obj)
    {
        colName = obj.gameObject.name;
        Debug.Log("이름: " + colName);
        direction = transform.position - obj.gameObject.transform.position;
        direction = direction.normalized * 3;
        Debug.Log("direction :" + direction);
        CollisionExist = true;
    }

    public void OnCollisionExit2D()
    {
        CollisionExist = false;
    }

    public void Rest()
    {
        Debug.Log("Rest");
    }



}
