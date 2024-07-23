using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// PlayerPrefs を使って値を保存する
/// </summary>
public class PlayerPrefsPatternSave : MonoBehaviour
{
    public void SaveName(InputField input)
    {
        PlayerPrefs.SetString("name", input.text);
    }
}
