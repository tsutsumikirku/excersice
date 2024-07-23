using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// static 変数を使って「シーンをまたいで値を渡す」方法
/// </summary>
public class StaticPattern : MonoBehaviour
{
    /// <summary>プレイヤーの名前。これをシーンまたぎで渡す</summary>
    public static string _name = "ああああ";
    /// <summary>メッセージを表示するテキスト</summary>
    [SerializeField] Text _text = default;
    [SerializeField] GameObject _gameobj;
    Transform _transform;
    public static Vector2 _playeraTransform;
    /// <summary>
    /// 名前を保存する
    /// </summary>
    /// <param name="input"></param>
    public void SetName(InputField input)
    {
        
        StaticPattern._name = input.text;
        _playeraTransform = _transform.position;


    }

    void Start()
    {
       _transform = _gameobj.GetComponent<Transform>();
        if(_playeraTransform.x == 0 && _playeraTransform.y == 0)
        {
            _playeraTransform = _transform.position;
        }
        else
        {
             _transform.position = _playeraTransform;
        }
        
      
        
        if (_text)
        {
            _text.text = $"よくぞ来た！勇者 <b><color=red>{StaticPattern._name}</color></b> よ！";
            Debug.Log(_text.text);
        }
    }
}
