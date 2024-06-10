using UnityEngine;

/// <summary>
/// 弾丸を制御するコンポーネント
/// </summary>
public class BulletController : MonoBehaviour
{
    /// <summary>弾が飛ぶ速さ</summary>
    [SerializeField] float m_speed = 3f;
    /// <summary>弾の生存期間（秒）</summary>
    [SerializeField] float m_lifeTime = 5f;

    void Start()
    {
 
        
        // 右方向に飛ばす
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * m_speed;
        // 生存期間が経過したら自分自身を破棄する
        Destroy(this.gameObject, m_lifeTime);
    }
}
