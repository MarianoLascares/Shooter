using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    
    void Start()
    {
        _text.text = "Puntuacion: " + PlayerPrefs.GetInt("High Score");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
