using UnityEngine;
using UnityEngine.UI;

class StartMenuPage : MonoBehaviour
{
    public string ForestSceneName;
    public string DistrictSceneName;
    public LoadingLogicPage LoadingLogic;
    public Button ForestButton;
    public Button DistrictButton;

    private void Awake()
    {
        ForestButton.onClick.AddListener(LoadForest);
        DistrictButton.onClick.AddListener(LoadDistrict);              
    }

    private void LoadForest()
    {
        LoadingLogic.LoadScene(ForestSceneName);
    }

    private void LoadDistrict()
    {
        LoadingLogic.LoadScene(DistrictSceneName);
    }

}

