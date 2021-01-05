using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicC : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Hello World!");

        // 1. 변수
        int level = 10;
        float strength = 15.5f;
        string playerName = "Mas";
        bool isFullLevel = true;

        Debug.Log(level);
        Debug.Log(strength);
        Debug.Log(playerName);
        Debug.Log(isFullLevel);

        // 2. 그룹형 변수
        string[] monsters = { "슬라임", "달팽이", "왕눈이" };
        int[] monsterLevel = new int[3];
        monsterLevel[0] = 1;
        monsterLevel[1] = 3;
        monsterLevel[2] = 5;

        Debug.Log(monsters[0]);
        Debug.Log(monsters[1]);
        Debug.Log(monsters[2]);
        Debug.Log(monsterLevel[0]); // 여기까지는 배열

        List<string> items = new List<string>();
        items.Add("회복 물약");
        items.Add("마나 물약");
        Debug.Log(items[0]);

        items.RemoveAt(0);
        Debug.Log(items[0]);
    }
}
