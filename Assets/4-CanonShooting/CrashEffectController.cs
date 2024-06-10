using UnityEngine;

/// <summary>
/// 爆発エフェクトを制御するコンポーネント
/// </summary>
public class CrashEffectController : MonoBehaviour
{
    /// <summary>生存期間（秒）。この時間が経過したらエフェクトを破棄する</summary>
    [SerializeField] float m_lifetime = 0.7f;

    void Start()
    {
        // Destroy 関数の第二引数に「何秒後に破棄するか」を指定できる
        Destroy(this.gameObject, m_lifetime);
    }
}
