using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Carta : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;

    public PowerUps powerUp;

    public void SetValues(PowerUps powerUp)
    {
        image.sprite = powerUp.image;
        text.SetText(powerUp.text);
        this.powerUp = powerUp;
    }
}
