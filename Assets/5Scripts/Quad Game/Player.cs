using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int equipWeaponIndex = -1;
    float hAxis;
    float vAxis;
    public float moveSpeed = 0.5f;
    public float jumpPower = 1f;
    public GameObject[] weapons;
    public GameObject[] grenades;
    public bool[] hasWeapons;
    public int hasGrenades = 0;

    public int ammo = 0;
    public int coin = 0;
    public int health = 100;

    int maxAmmo = 999;
    int maxCoin = 99999;
    int maxHealth = 100;
    int maxHasGrenades = 4;

    Vector3 moveVec;
    Vector3 dodgeVec;

    Animator anim;
    Rigidbody rigid;
    GameObject nearObject;
    GameObject equipWeapon;

    bool wDown;
    bool jDown;
    bool iDown;
    bool isJump = false;
    bool isDodge;
    bool isSwap; // 캐릭터 이동과 조작 변수

    bool sDown1;
    bool sDown2;
    bool sDown3; // 아이템 클릭 변수

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput(); // 제일 위에 있어야 함
        Move();
        Turn();
        Jump();
        Dodge();
        Interaction();
        Swap();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
            anim.SetBool("isJump", false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            Item item = other.GetComponent<Item>();
            switch(item.type)
            {
                case Item.Type.Ammo:
                    ammo += item.value;
                    if (ammo > maxAmmo)
                        ammo = maxAmmo;
                    break;
                case Item.Type.Coin:
                    coin += item.value;
                    if (coin > maxCoin)
                        coin = maxCoin;
                    break;
                case Item.Type.Grenade:
                    hasGrenades  += item.value;
                    if (hasGrenades > maxHasGrenades)
                        hasGrenades = maxHasGrenades;
                    break;
                case Item.Type.Heart:
                    health += item.value;
                    if (health > maxHealth)
                        health = maxHealth;
                    break;
            }
            Destroy(other.gameObject);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weapon")
            nearObject = other.gameObject;
        Debug.Log(nearObject);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Weapon")
            nearObject = null;
    }
    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
        iDown = Input.GetButtonDown("Interaction");

        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
        sDown3 = Input.GetButtonDown("Swap3");
    } // 입력 함수
    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (isSwap)
            moveVec = Vector3.zero;

        if (isDodge)
            moveVec = dodgeVec;

        transform.position += moveVec * moveSpeed * (wDown ? 0.3f : 1f) * Time.deltaTime; // 삼항 연산자

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

    } // 캐릭터 이동 함수
    void Turn()
    {
        transform.LookAt(transform.position + moveVec); // 우리가 나아가는 방향으로 바라본다.
    } // 캐릭터 회전 함수
    void Jump()
    {
        if (jDown && moveVec == Vector3.zero && !isJump && !isDodge && !isSwap)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }
    void Dodge()
    {
        if(jDown && moveVec != Vector3.zero && !isJump && !isDodge && !isSwap)
        {
            dodgeVec = moveVec;
            moveSpeed *= 2;
            anim.SetTrigger("doDodge");
            isDodge = true;

            Invoke("DodgeOut", 0.6f);
        }
    }
    void DodgeOut()
    {
        moveSpeed *= 0.5f;
        isDodge = false;
    }
    void Interaction()
    {
        if(iDown && nearObject != null && !isJump && !isDodge)
        {
            if(nearObject.tag == "Weapon")
            {
                Item item = nearObject.GetComponent<Item>();
                int indexWeapon = item.value;
                hasWeapons[indexWeapon] = true;

                Destroy(nearObject);
            }
        }
    }
    void Swap()
    {
        if (sDown1 && (!hasWeapons[0] || equipWeaponIndex == 0))
            return;
        if (sDown2 && (!hasWeapons[1] || equipWeaponIndex == 1))
            return;
        if (sDown3 && (!hasWeapons[2] || equipWeaponIndex == 2))
            return;

        int weaponIndex = -1; // 일단 값을 못 바꾸도록 음수 지정

        if (sDown1) weaponIndex = 0;
        if (sDown2) weaponIndex = 1;
        if (sDown3) weaponIndex = 2;

        if ((sDown1 || sDown2 || sDown3) && !isJump && !isDodge)
        {
            if(equipWeapon != null)
                equipWeapon.SetActive(false);

            equipWeaponIndex = weaponIndex;
            equipWeapon = weapons[weaponIndex];
            equipWeapon.SetActive(true);

            anim.SetTrigger("doSwap");

            isSwap = true;

            Invoke("SwapOut", 0.5f);
        }
    }
    void SwapOut()
    {
        isSwap = false;
    }
}
