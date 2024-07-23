using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// JSON として PlayerPrefs に保存したデータを読み込み、
/// インスタンスに復元（逆シリアル化、デシリアライズ）する。
/// </summary>
public class JSONLoad : MonoBehaviour
{
    [SerializeField] Text _text = default;

    public void Load()
    {
        // PlayerPrefs から文字列を取り出す
        string json = PlayerPrefs.GetString("SaveData");
        // デシリアライズする
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        // 画面に表示する
        string status = "Name: " + saveData.Name + "\r\nLevel: " + saveData.Level
            + "\r\nHP: " + saveData.Hp + " / " + saveData.MaxHp;
        _text.text = status;
    }
}
