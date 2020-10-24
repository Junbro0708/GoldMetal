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
        // rigid.velocity = Vector3.right; 오른쪽으로 방향을 주는 코드
        // rigid.velocity = new Vector3(3, 4, 2); // 만약 계속 속도를 주고 싶다면 업데이트가 아닌 픽스트 업데이트에 써야 한다.
        rigid.AddForce(Vector3.up * 50, ForceMode.Impulse); // 벡터 방향과 힘, 그리고 힘의 형식을 부여할 수 있다. 보통 캐릭터의 점프에 사용
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
