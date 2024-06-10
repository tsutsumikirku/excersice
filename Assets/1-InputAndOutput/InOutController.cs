using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutController : MonoBehaviour
{
    void Start()
    {
        Debug.Log("開始");
    }

    void Update()
    {
        // 方向の入力を検出する

        float h = Input.GetAxisRaw("Horizontal");  // h は Horizontal（水平）の h
        float v = Input.GetAxisRaw("Vertical");    // v は Vertical（垂直）の v

        if (h != 0 || v != 0)
        {
            Debug.Log("x: " + h.ToString() + ", y: " + v.ToString());
        }

        // ジャンプボタンを検出する

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
        }

        // T キーを検出する

        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("Tが押されている");
        }

        // マウスボタンを検出する

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("左クリックが離された");
        }
    }
}
