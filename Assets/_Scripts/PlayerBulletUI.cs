using TMPro;
using UnityEngine;

public class PlayerBulletUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    public PlayerShooting targetShooting;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _text.text = "Bullets: " + targetShooting.bulletsAmount;
    }
}
