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
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * moveSpeed * (wDown ? 0.3f : 1f) * Time.deltaTime; // 삼항 연산자

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

        transform.LookAt(transform.position + moveVec); // 우리가 나아가는 방향으로 바라본다.
    }
}
