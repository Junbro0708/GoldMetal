using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PalyerBall : MonoBehaviour
{
    Rigidbody rigid;
    public float jumpPower = 10;
    public int item_cnt = 0;
    public GameManeger manager;
    int jump_cnt = 0;
    AudioSource audio;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>(); // 유니티의 컴포넌트를 스크립트에 가져옴
        audio = GetComponent<AudioSource>();
        jump_cnt = 0;
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && (jump_cnt == 0 || jump_cnt == 1))
        {
            jump_cnt += 1;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse); // 기본적인 이동 설정
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            jump_cnt = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            item_cnt++;
            audio.Play();
            manager.GetItemCount(item_cnt);
            other.gameObject.SetActive(false);
        }
        if (other.tag == "Finish")
        {
            if(item_cnt == manager.totalItemCount)
            {
                if (manager.stage == 2)
                {
                    SceneManager.LoadScene("GameScene1_0");
                }
                else
                {
                    SceneManager.LoadScene("GameScene1_" + (manager.stage + 1).ToString());
                }
            }
            else
            {
                //Restart
                SceneManager.LoadScene("GameScene1_" + (manager.stage).ToString());
            }
        }
    }
}
