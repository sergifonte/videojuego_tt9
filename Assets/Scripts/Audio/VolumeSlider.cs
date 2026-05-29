using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    private const string MIXER_PARAMETER = "MasterVol"; //master es troba l'apartat Assets->audio+musicaa

    void Start()
    {
        if (volumeSlider == null || audioMixer == null) return;

        float currentVolume; //volum actual
        if (audioMixer.GetFloat(MIXER_PARAMETER, out currentVolume))
        {
            volumeSlider.value = currentVolume; //posició correcta al començar
        }

        //event de canvi de volum
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float sliderValue)
    {
        audioMixer.SetFloat(MIXER_PARAMETER, sliderValue);
    }

    void OnDestroy()
    {
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.RemoveListener(SetVolume);
        }
    }
}