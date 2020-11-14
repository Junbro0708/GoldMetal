using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMove2 : MonoBehaviour
{
    Vector3 target = new Vector3(12, 1f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. MoveTowards
        transform.position =
            Vector3.MoveTowards(transform.position, target, 1f); // 등속이동 마지막 매개변수에 따라 속도가 달라짐
        // MoveTowards는 현재위치와 목표위치 벡터의 값과 속도를 받음

        // 2. SmoothDamp
        Vector3 velo = Vector3.zero; // 참조속도에 값을 넣으면 함께 계산이 가능하지만, 목표위치의 개념이 사라지므로 보통은 넣지 않는다.

        transform.position =
            Vector3.SmoothDamp(transform.position,
            target, ref velo, 0.5f); // 현재위치 목표위치 참조속도 속도의 매개변수를 받는다. 1번과 다르게 매개변수가 작아지면 속도가 증가하고, 일정한 속도가 아닌 부드럽게

        // 3. Lerp 선형 보간 방식 스무스댐프보다 감속시간이 길다.
        transform.position =
            Vector3.Lerp(transform.position, target, 0.1f); // 속도는 0-1사이의 값

        // 4. Slerp 구면 선형 보간 방식
        transform.position =
            Vector3.Slerp(transform.position, target, 0.1f); // 포물선 이동
    }

}
