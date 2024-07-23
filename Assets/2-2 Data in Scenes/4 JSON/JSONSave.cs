using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// JSON 形式に変換（シリアライズ、シリアル化）して PlayerPrefs に保存する
/// </summary>
public class JSONSave : MonoBehaviour
{
    [SerializeField] InputField _nameInput = default;
    [SerializeField] InputField _levelInput = default;
    [SerializeField] InputField _maxHpInput = default;
    [SerializeField] InputField _hpInput = default;

    public void Save()
    {
        // インスタンスを作る
        int level = int.Parse(_levelInput.text);
        int maxHp = int.Parse(_maxHpInput.text);
        int hp = int.Parse(_hpInput.text);
        SaveData saveData = new SaveData(_nameInput.text, level, maxHp, hp);

        // インスタンス変数を JSON にシリアル化する
        string json = JsonUtility.ToJson(saveData);
        Debug.Log($"JSON: {json}");

        // PlayerPrefs に保存する
        PlayerPrefs.SetString("SaveData", json);
    }
}
