using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioMixer mixer;


    private void Start()
    {
        slider.value = 0.5f;
        UpdateSetting(slider.value);
        slider.onValueChanged.AddListener(UpdateSetting);
    }

    public void UpdateSetting(float newValue)
    {
        float mult = 20;
        mixer.SetFloat("masterVol", Mathf.Log10(newValue) * mult);
    }
}
