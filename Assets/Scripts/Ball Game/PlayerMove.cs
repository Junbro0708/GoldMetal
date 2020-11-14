using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) // Input은 키를 입력받는 함수이고, anyKeyDown은 아무 키를 눌렀을 때
            Debug.Log("플레이어가 아무키를 눌렀습니다.");
        if(Input.anyKey) // anyKey는 아무 키를 누르고있을 때
            Debug.Log("플레이어가 아무키를 누르고 있습니다.");

        //----------------------------------------------------------------------

        //입력함수는 버튼이 눌렸을 때, 버튼을 누르고 있을때, 버튼이 눌렸다 떼졌을때 총 세가지 행동양식으로 나눌 수 있다.
        if(Input.GetKeyDown(KeyCode.Return)) // KeyCode는 매개변수 Return은 엔터키
            Debug.Log("플레이어가 아이템을 구매하였습니다.");

        if (Input.GetKey(KeyCode.LeftArrow)) // KeyCode의 오른쪽은 키보드 자판으로 리턴이 엔터, 이스케이프가 ESC이다.
            Debug.Log("플레이어가 왼쪽으로 이동중");

        if (Input.GetKeyUp(KeyCode.RightArrow)) // 애로우는 화살표
            Debug.Log("플레이어가 오른쪽으로 이동중");

        //----------------------------------------------------------------------

        if (Input.GetMouseButtonDown(0)) // 위의 키를 마우스버튼으로 바꾸면 마우스 클릭
            Debug.Log("미사일 발사!");

        if (Input.GetMouseButton(0)) // 마우스버튼은 매개변수를 숫자로 받는데 0과 1을 대표적으로 받는다. 0은 왼쪽버튼 1은 오른쪽 버튼
            Debug.Log("미사일 모으는 중...");

        if (Input.GetMouseButtonUp(0)) 
            Debug.Log("슈퍼 미사일 발사!");

        //----------------------------------------------------------------------

        if (Input.GetButtonDown("Jump")) // 유니티의 기본 인풋 매니저에 있는 값을 이용해 키를 받는 것. 매개변수로 이미 지정되어있는 키워드를 받는다.
            Debug.Log("Jump!");

        if (Input.GetButton("Jump")) // Jump는 스페이스바 (대소문자 구분 필수!)
            Debug.Log("Ready to jump");

        if (Input.GetButtonUp("Jump"))
            Debug.Log("Super Jump!");

    }
}
