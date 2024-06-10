using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableController : MonoBehaviour
{
    void Start()
    {
        // 変数と型（組み込み型）

        int a = 2;
        Debug.Log(a);

        float b = 1.5f;
        Debug.Log(b);

        string c = "abc";   // 文字列は " （ダブルクォーテーション、二重引用符）で囲む
        Debug.Log(c);

        string d = "def";
        Debug.Log(d);

        //int f = a + b;  // これはできない
        //Debug.Log(f);

        float g = a + b;
        Debug.Log(g);

        string h = c + d;   // 文字列も足し算できる
        Debug.Log(h);

        //string i = 2 * c;   // 文字列の掛け算は（C# では）できない
        //Debug.Log(i);

        // 以降に課題のコードを記述せよ。
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
