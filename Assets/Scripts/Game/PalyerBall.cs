using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerBall : MonoBehaviour
{
    Rigidbody rigid;
    public float jumpPower = 10;
    bool isJump;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>(); // 유니티의 컴포넌트를 스크립트에 가져옴
        isJump = false;
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse); // 기본적인 이동 설정
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            isJump = false;
        }
    }
}
