using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hAxis;
    float vAxis;
    public float moveSpeed = 0.5f;
    Vector3 moveVec;
    Animator anim;
    bool wDown;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput(); // 제일 위에 있어야 함
        Move();
        Turn();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
    } // 입력 함수
    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * moveSpeed * (wDown ? 0.3f : 1f) * Time.deltaTime; // 삼항 연산자

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
    } // 캐릭터 이동 함수
    void Turn()
    {
        transform.LookAt(transform.position + moveVec); // 우리가 나아가는 방향으로 바라본다.
    } // 캐릭터 회전 함수
}
