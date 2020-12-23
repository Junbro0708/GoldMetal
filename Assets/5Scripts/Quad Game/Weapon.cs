﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Melee, Range };
    public Type type;
    public int damage;
    public float rate;
    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;

    public void Use()
    {
        if(type == Type.Melee)
        {
            StopCoroutine("Swing"); // 코루틴이 이미 실행되고 있을 수 있기 때문에 멈추게한 다음 다시 실행 
            StartCoroutine("Swing");
        }
    }

    //Use() 메인 루틴 -> Swing() 서브 루틴 -> Use() 메인 루틴 : 일반적인 함수의 진행 순서
    //Use() 메인 루틴 + Swing() 코 루틴 : 메인 루틴과 코 루틴 함께 진행

    IEnumerator Swing()
    {
        //1
        yield return new WaitForSeconds(0.1f); // 코 루틴에서는 yield가 적어도 하나는 필요 -> 반환값은 전달해 주는 것 // 0.1초 대기
        //2
        meleeArea.enabled = true;
        trailEffect.enabled = true;

        yield return new WaitForSeconds(0.3f);
        //3         yield return null; // 1 프레임 대기
        meleeArea.enabled = false;

        yield return new WaitForSeconds(0.3f);
        // 4
        trailEffect.enabled = false;

        yield break;
    }
}
