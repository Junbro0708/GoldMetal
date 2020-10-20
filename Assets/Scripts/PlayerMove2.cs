using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
            Debug.Log("플레이어가 아무키나 눌렀습니다.");

        if(Input.GetButton("Horizontal"))
        {
            Debug.Log("플레이어가 횡 이동 중..."
                + Input.GetAxis("Horizontal")); // GetAxis는 반환 타입이 float값이다.
            //GetAxis가 아닌 GetAxisRaw를 사용하면 가중치가 아닌 -1과 1, 두개 키를 동시에 누르면 0이 나온다.
        }
        if (Input.GetButton("Vertical"))
        {
            Debug.Log("플레이어가 종 이동 중..."
                + Input.GetAxisRaw("Vertical")); // GetAxis는 반환 타입이 float값이다.
            //GetAxis가 아닌 GetAxisRaw를 사용하면 가중치가 아닌 -1과 1, 두개 키를 동시에 누르면 0이 나온다.
        }
    }
}
