using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall : MonoBehaviour
{
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>(); // Rogidbody의 요소를 다져오는 줄 - 컴포넌트를 사용가능해진다.
        rigid.velocity = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
