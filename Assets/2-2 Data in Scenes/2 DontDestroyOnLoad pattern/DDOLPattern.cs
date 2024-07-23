using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// DontDestroyOnLoad を使って「シーンをまたいで値を渡す」方法
/// </summary>
public class DDOLPattern : MonoBehaviour
{
    /// <summary>メッセージを表示する Text オブジェクトの名前</summary>
    [SerializeField] string _messageTextName = "MessageText";
    /// <summary>プレイヤーの名前。これをシーンまたぎで渡す</summary>
    [SerializeField] string _name = "ああああ";
    [SerializeField] GameObject bird;
    /// <summary>Start 関数の処理が終わっているか表すフラグ</summary>
    bool _isStarted = false;

    void Start()
    {
        if (FindObjectsOfType<DDOLPattern>().Length > 1)
        {
            // 重複しないように、既にある時は自分自身を破棄する
            Destroy(this.gameObject);
        }
        else
        {
            // 自分しかいない時は、自分を DontDestroyOnLoad に登録する
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(bird);
            ShowMessage();
            _isStarted = true;
        }
    }

    /// <summary>
    /// 名前を保存する
    /// </summary>
    /// <param name="input"></param>
    public void SetName(InputField input)
    {
        _name = input.text;
    }

    /// <summary>
    /// シーンがロードされた時に呼ばれる。
    /// この関数を使うと警告が出て、代わりに SceneManager.sceneLoaded を使うよう促される。
    /// しかし、これを使うにはデリゲートを知らなければならないので、今はこちらを使う。
    /// </summary>
    /// <param name="level"></param>
    void OnLevelWasLoaded(int level)
    {
        if (_isStarted) ShowMessage();
    }

    /// <summary>
    /// メッセージを表示する
    /// </summary>
    void ShowMessage()
    {
        GameObject go = GameObject.Find(_messageTextName);
        Text text = go?.GetComponent<Text>();

        if (text)
        {
            text.text = $"おお！<b><color=red>{_name}</color></b> よ！しんでしまうとは なにごとだ！";
            Debug.Log(text.text);
        }
    }
}
