using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Carta : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text text;

    public PowerUps powerUp;

    public void SetValues(PowerUps powerUp)
    {
        image.sprite = powerUp.image;
        text.text = powerUp.text;
        this.powerUp = powerUp;
    }
}
