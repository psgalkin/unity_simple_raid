using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class LoadingLogicPage : MonoBehaviour
{
    public Slider ProgressBarSlider;
    public GameObject VisualPart;
    public float FakeLoadTime = 1f;

    public GameObject DistrictText;
    public GameObject ForestText;

    private void Awake()
    {       
        DontDestroyOnLoad(gameObject);
        DistrictText.SetActive(false);
        ForestText.SetActive(false);
        VisualPart.SetActive(false);       
    }

    public void LoadScene(string p_sceneName)
    {
        StartCoroutine(LoadGaneSceneCor(p_sceneName));
    }

    private IEnumerator LoadGaneSceneCor(string p_sceneName)
    {
        VisualPart.SetActive(true);
        if (p_sceneName == "3_district") {
            DistrictText.SetActive(true);
        }
        else if (p_sceneName == "3_forest") {
            ForestText.SetActive(true);
        }

        AsyncOperation asyncLoading = SceneManager.LoadSceneAsync(p_sceneName);
        asyncLoading.allowSceneActivation = false;

        float timer = 0;

        while (timer < FakeLoadTime || asyncLoading.progress < 0.9f)
        {
            timer += Time.deltaTime;
            SetProgressByTimeStep(timer, FakeLoadTime);

            yield return null ;
        }

        asyncLoading.allowSceneActivation = true;
        
        yield return new WaitForSeconds(0.5f);

        VisualPart.SetActive(false);
        Destroy(gameObject);
    }

    private void SetProgressByTimeStep(float timer, float loadTime)
    {
        ProgressBarSlider.value = timer / loadTime;
    }
}
