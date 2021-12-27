using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    public float maxSpeed;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 pos;
    public GameObject Clear;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Clear.SetActive(false);
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");


        //자동차 가로세로 움직임, y position freeze하기 
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp= Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;

    }
    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v); //세로로는 움직x
        rigid.velocity = moveVec * maxSpeed;
        pos = rigid.position;

        // exit 선이 x=1 선에 있다고 가정
        if (pos.x>180)  
        {
            Time.timeScale = 0; //시간 멈춤
            Debug.Log("탈출 성공");
            Clear.SetActive(true);
        }
        
      
    }

    //부딪히면 멈추는 방식
    void OnTriggerEnter2D(Collider2D collision)
    {
      //  if (collision.GameObject.tag == "Finish")
       // {
        //    Time.timeScale = 0; //멈춤
       //     Debug.Log("게임 클리어");

      //  }
    }


}
