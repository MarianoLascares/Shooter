using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
