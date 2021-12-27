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

    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
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
        RotationPos = this.GetComponent<RectTransform>().eulerAngles.z; ;
        Debug.Log("위치: " + DefaultPos + "    " + "각도: " + RotationPos);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;

        while(CollisionExist == false)
        {
            if (RotationPos == 90.0)
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
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = DefaultPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionExist = true;
    }

   
}
