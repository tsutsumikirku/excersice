using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// キャラクターを制御するコンポーネント
/// キャラクターにアタッチして使う。Rigidbody2D を必要とする。
/// ボタンでジャンプする。
/// 何かにぶつかったらゲームオーバーにする。
/// </summary>
public class BirdFlapController : MonoBehaviour
{
    /// <summary>スペースキーを押した時に上昇する力</summary>
    [SerializeField] float m_jumpPower = 1f;
    /// <summary>Game Over を表示するオブジェクト</summary>
  [SerializeField] GameObject m_gameoverText = default;
    /// <summary>経過時間を表示するオブジェクト</summary>
    GameObject m_timeText = default;
    /// <summary>ゲームオーバーかどうかを判断するフラグ</summary>
  
    Animator m_anim = default;
    Rigidbody2D m_rb = default;
    Text text;
    int a = 0;

    void Start()
    {
     
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        // シーンから、適切なオブジェクトを検索・取得する
       
        m_timeText = GameObject.Find("TimeText");
    }

    void Update()
    {
        // ジャンプボタンが押されたら上昇する
        if (Input.GetButtonDown("Jump"))
        {
            m_anim.Play("Flap");
            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
        }

        // TimeText にプレイ時間を表示する
        if(a == 0)
        m_timeText.GetComponent<Text>().text = Time.time.ToString("F2");    // F2 で「小数点以下２桁まで」を指定して、実数を文字列に変換する（参考: https://dobon.net/vb/dotnet/string/inttostring.html）
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("何かにぶつかった！");

        // 何かにぶつかったらゲームオーバーとする
        
        // 画面に Game Over と表示する
        Text gameoverText = m_gameoverText.GetComponent<Text>();
        gameoverText.text = "Game Over";
        a = 1;

    }
   
}
