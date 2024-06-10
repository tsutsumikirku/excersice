using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// ガンマンのキャラクターを操作するコンポーネント
/// </summary>
public class GunmanController : MonoBehaviour
{
    /// <summary>左右移動する力</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 15f;
    /// <summary>色の配列</summary>
    [SerializeField] Color[] m_colors = default;
    /// <summary>弾丸のプレハブ</summary>
    [SerializeField] GameObject m_bulletPrefab = default;
    [SerializeField] GameObject m_bulletPrefab2 = default;
    /// <summary>銃口の位置を設定するオブジェクト</summary>
    [SerializeField] Transform m_muzzle = default;
    /// <summary>入力に応じて左右を反転させるかどうかのフラグ</summary>
    [SerializeField] bool m_flipX = true;
    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;
    /// <summary>m_colors に使う添字</summary>
    int m_colorIndex;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    float m_scaleX;
    /// <summary>最初に出現した座標</summary>
    Vector3 m_initialPosition;
    int j = -1;
    int i = 0;
    int k = 0;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        // 初期位置を覚えておく
        m_initialPosition = this.transform.position;
    }

    void Update()
    {
        if (i == 1)
        {
            if (Input.GetButtonDown("Jump"))
            {


                m_rb.AddForce(Vector2.up * m_jumpPower * m_movePower, ForceMode2D.Force);
                i = 0;

                // Debug.Log("ここにジャンプする処理を書く。");
            }
        }
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");

        // 各種入力を受け取る
       

        if (Input.GetButtonDown("Fire1"))
        {
            if (transform.localScale.x == 1)
            {
                Instantiate(m_bulletPrefab).transform.position = m_muzzle.transform.position;
            }
            if (transform.localScale.x == -1)
            {
                Instantiate(m_bulletPrefab2).transform.position = m_muzzle.transform.position;
            }









            //Debug.Log("ここに弾を発射する処理を書く。");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            j += 1;
             m_sprite.color = m_colors[j];
            if(j == 2)
            {
                j = -1;
            }
           
            //Debug.Log("ここに色を切り替える処理を書く。");
        }

        // 下に行きすぎたら初期位置に戻す
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }

        // 設定に応じて左右を反転させる
        if (m_flipX)
        {
            FlipX(m_h);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (k == 1 && Input.GetButton("Jump"))
        {
            

                k = 0;
                m_rb.AddForce(Vector2.up * m_jumpPower * m_movePower, ForceMode2D.Force);

                // Debug.Log("ここにジャンプする処理を書く。");
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        i = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        k = 1;
        i = 0;
    }
    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        m_rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);
    }

    /// <summary>
    /// 左右を反転させる
    /// </summary>
    /// <param name="horizontal">水平方向の入力値</param>
    void FlipX(float horizontal)
    {
        /*
         * 左を入力されたらキャラクターを左に向ける。
         * 左右を反転させるには、Transform:Scale:X に -1 を掛ける。
         * Sprite Renderer の Flip:X を操作しても反転する。
         * */
        m_scaleX = this.transform.localScale.x;

        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
  
}
