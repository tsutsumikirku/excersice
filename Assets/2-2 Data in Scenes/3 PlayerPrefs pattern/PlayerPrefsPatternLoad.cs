using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// PlayerPrefs から値を取り出す
/// </summary>
public class PlayerPrefsPatternLoad : MonoBehaviour
{
    [SerializeField] Text m_messageText = default;

    void Start()
    {
        if (m_messageText)
        {
            string name = PlayerPrefs.GetString("name");
            m_messageText.text = $"もし わしの みかたになれば せかいの はんぶんを <b><color=red>{name}</color></b> にやろう。";
        }
    }
}
