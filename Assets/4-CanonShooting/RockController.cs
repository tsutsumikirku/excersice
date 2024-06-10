using UnityEngine;

/// <summary>
/// 落ちてくる岩を制御するコンポーネント
/// 砲弾に当たるとエフェクトを表示（生成）して消える
/// </summary>
public class RockController : MonoBehaviour
{
    /// <summary>砲弾が当たった時に表示されるエフェクト</summary>
    [SerializeField] GameObject m_effectPrefab = default;

    void Update()
    {
        // 下に落ちたら自分自身を破棄する
        if (this.transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shell")
        {
            // エフェクトとなるプレハブが設定されていたら、それを生成する
            if (m_effectPrefab)
            {
                Instantiate(m_effectPrefab, this.transform.position, this.transform.rotation);
            }

            // 自分自身を破棄する
            Destroy(this.gameObject);
        }
    }
}
