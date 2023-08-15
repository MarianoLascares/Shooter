using TMPro;
using UnityEngine;

public class EnemiesUI : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        EnemyManager.SharedInstance.onEnemyChanged.AddListener(RefreshText);
        RefreshText();
    }

    private void RefreshText()
    {
        _text.text = "REMAINING ENEMIES: " + EnemyManager.SharedInstance.EnemyCount;
    }
}
