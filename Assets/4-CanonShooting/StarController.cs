using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Star を制御するコンポーネント
/// </summary>
public class StarController : MonoBehaviour
{
    [SerializeField]GameObject stargets = default(GameObject);
    void Update()
    {
        if (this.transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 砲弾が当たった時
        if (collision.gameObject.tag == "Shell")
        {
            // AudioSource コンポーネントを取得して音を鳴らす
            Instantiate(stargets);
            Destroy(this.gameObject);
        }
    }
}
