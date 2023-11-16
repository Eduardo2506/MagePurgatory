using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Carta : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI descriptionText;

    public PowerUps powerUp;

    public void SetValues(PowerUps powerUp)
    {
        image.sprite = powerUp.image;
        text.text = powerUp.text;
        descriptionText.text = powerUp.description;//
        this.powerUp = powerUp;
    }
}
