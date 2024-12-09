using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void setScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
