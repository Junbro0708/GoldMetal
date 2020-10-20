using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int num = 3; // 이건 스칼라 값이고, 여기서 방향이 들어가면 벡터
        Vector3 vec = new Vector3(0, 0, 0); // 벡터 선언

        // 오브젝트를 생성하면 무조건 트랜스폼 클래스가 생성이 되고 개발의 편의를 위해 객체를 생성해주지 않고 바로 사용이 가능하다.
        transform.Translate(vec); // 움직이지 않는 이유는 vec의 값이 0,0,0 이기 때문

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            Input.GetAxis("Horizontal") * Time.deltaTime, // Time.deltaTime은 컴퓨터의 성능에 상관없이 일정하게 움직이도록 만들어주는 소스
            // Time.deltaTime : 이전 프레임의 완료까지 걸린 시간
            // Time.deltaTime은 Translate에서는 벡터에 곱해주고, Vector3에서는 시간에 곱해준다.
            Input.GetAxis("Vertical"), 0);
    }
}
