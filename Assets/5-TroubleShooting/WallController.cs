using UnityEngine;

/// <summary>
/// 壁を制御するコンポーネント
/// 壁のオブジェクトにアタッチして使う。
/// 壁を一定速度で左に動かし、ある程度左に行ったら破棄する。
/// </summary>
public class WallController : MonoBehaviour
{
    /// <summary>左に動く速さ</summary>
    [SerializeField] float m_moveSpeed = 1f;

    void Update()
    {
        // ある程度左に行ったら
        if (this.transform.position.x < -10f)
        {
            // 自分自身を破棄する
            Destroy(this.gameObject);
        }

        // 一定速度で左に動かす
        this.transform.Translate(Vector2.left * m_moveSpeed * Time.deltaTime);
    }
}
