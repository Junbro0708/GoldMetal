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
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"), 0);
    }
}
