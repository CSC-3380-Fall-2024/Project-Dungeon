using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls_Menu : MonoBehaviour
{
    public void backScene()
    {
        SceneManager.LoadScene("Options Menu");
    }
}
