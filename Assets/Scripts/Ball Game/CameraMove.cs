using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransform;
    Vector3 offset;

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position; // 카메라 벡터 - 공의 벡터
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
    }
}
