using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

class PauseMenuPage : MonoBehaviour
{
    [Serializable]
    public class VolumeSliderData
    {
        public Slider VolumeSlider;
        public Text VolumeText;
        public string VolumeParamNameInMixer;
        private AudioMixer Mixer;

        public void SliderValueChanged(float param)
        {
            Mixer.SetFloat(VolumeParamNameInMixer, param);
            VolumeText.text = param.ToString("F0");
        }

        public void Init(AudioMixer p_mixer)
        {
            Mixer = p_mixer;
            float CurrentBGVolume;
            Mixer.GetFloat(VolumeParamNameInMixer, out CurrentBGVolume);
            VolumeText.text = CurrentBGVolume.ToString("F0");
            VolumeSlider.value = CurrentBGVolume;

            VolumeSlider.onValueChanged.AddListener(SliderValueChanged);
        }
    }

    public GameObject PauseUI;
    public GameObject GameUI;
    public string MenuSceneName;
    public AudioMixer Mixer;

    public VolumeSliderData[] VolumeSliders;

    private void Start()
    {
        PauseUI.SetActive(false);

        foreach (VolumeSliderData VolumeSlider in VolumeSliders) {
            VolumeSlider.Init(Mixer);
        }
    }


    public void Pause()
    {
        GameUI.SetActive(false);
        Time.timeScale = 0;
        PauseUI.SetActive(true);
    }

    public void GoToMenu()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(MenuSceneName);
    }

    public void Continue()
    {
        PauseUI.SetActive(false);

        Time.timeScale = 1;
        GameUI.SetActive(true);
    }

    public void Restart()
    {
        PauseUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1;
        GameUI.SetActive(true);
    }
}
