using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    private const string MIXER_PARAMETER = "MasterVol";

    void Start()
    {
        // Comprovem si tenim les referències assignades
        if (volumeSlider == null || audioMixer == null) return;

        // Recuperem el volum actual del Mixer per posar el slider a la posició correcta al començar
        float currentVolume;
        if (audioMixer.GetFloat(MIXER_PARAMETER, out currentVolume))
        {
            volumeSlider.value = currentVolume;
        }

        // Subscrivim de forma dinàmica l'esdeveniment de canvi de valor
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float sliderValue)
    {
        // Passem el valor del slider directament al paràmetre exposed del Mixer
        audioMixer.SetFloat(MIXER_PARAMETER, sliderValue);
    }

    void OnDestroy()
    {
        // Bona pràctica: netegem el listener quan l'objecte es destrueix
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.RemoveListener(SetVolume);
        }
    }
}