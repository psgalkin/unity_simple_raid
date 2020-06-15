using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    public GameObject EndUI;
    public GameObject GameUI;

    public GameObject WinObjs;
    public GameObject LossObjs;

    public string MenuSceneName;

    private void Start()
    {
        
        EndUI.SetActive(false);
        WinObjs.SetActive(false);
        LossObjs.SetActive(false);
    }

    public void StartWinUI()
    {
        //Time.timeScale = 0;
        WinObjs.SetActive(true);
        GameUI.SetActive(false);
        EndUI.SetActive(true);
        EndUI.GetComponentInChildren<EndGameSounds>().PlayWinSound();
    }

    public void StartLossUI()
    {
        //Time.timeScale = 0;
        LossObjs.SetActive(true);
        GameUI.SetActive(false);
        EndUI.SetActive(true);
        EndUI.GetComponentInChildren<EndGameSounds>().PlayLossSound();
    }

    public void GoToMenu()
    {
        LossObjs.SetActive(false);
        EndUI.SetActive(false);
        EndUI.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(MenuSceneName);
    }


    public void Restart()
    {
        LossObjs.SetActive(false);
        EndUI.SetActive(false);
        EndUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1;
        GameUI.SetActive(true);
    }
}
