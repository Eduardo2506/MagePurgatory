using UnityEngine;
using UnityEngine.UI;

public class SettinsMenu : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image mute;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarMute();
    }
    public void CambiarSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarMute();
    }
    public void RevisarMute()
    {
        if (sliderValue == 0)
        {
            mute.enabled = true;
        }
        else
        {
            mute.enabled = false;
        }
    }
}
