using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneController : MonoBehaviour
{

    [SerializeField] GameObject marketPanel,customizePanel,chaptersPanel;
    [SerializeField] GameObject muteImage;

    private void Start()
    {
        marketPanel.SetActive(false);
        customizePanel.SetActive(false);
        chaptersPanel.SetActive(false);
    }


    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }


    public void QuitButton()
    {
        Application.Quit();
    }

    public void MarketButton()
    {

        if (marketPanel.activeInHierarchy)
        {
            marketPanel.SetActive(false);
        }
        else
        {
            marketPanel.SetActive(true);
            customizePanel.SetActive(false);
            chaptersPanel.SetActive(false);
        }
    }

    public void CutomizeButton()
    {

        if (customizePanel.activeInHierarchy)
        {
            customizePanel.SetActive(false);
        }
        else
        {
            customizePanel.SetActive(true);
            marketPanel.SetActive(false);
            chaptersPanel.SetActive(false);
        }
    }


    public void ChaptersButton()
    {

        if (chaptersPanel.activeInHierarchy)
        {
            chaptersPanel.SetActive(false);
        }
        else
        {
            chaptersPanel.SetActive(true);
            customizePanel.SetActive(false);
            marketPanel.SetActive(false);
            
        }
    }

    public void MuteButton()
    {
        if (muteImage.activeInHierarchy)
        {
            muteImage.SetActive(false);
            AudioListener.pause = true;
        }
        else
        {
            muteImage.SetActive(true);
            AudioListener.pause = false;
        }
    }


}
