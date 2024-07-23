using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンロード用のコンポーネント
/// </summary>
public class SceneLoader : MonoBehaviour
{
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Load(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Load(Dropdown dropDown)
    {
        Load(dropDown.value);
    }

    public void Load(InputField inputField)
    {
        Load(inputField.text);
    }
}
