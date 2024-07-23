using System;

/// <summary>
/// ゲームのデータ
/// </summary>
[Serializable]  // これをつけることでシリアル化ができるようになる
public class SaveData
{
    public string Name;
    public int Level;
    public int MaxHp;
    public int Hp;

    public SaveData(string name, int level, int maxHp, int hp)
    {
        this.Name = name;
        this.Level = level;
        this.MaxHp = maxHp;
        this.Hp = hp;
    }
}
