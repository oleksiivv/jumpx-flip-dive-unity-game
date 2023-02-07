using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : BaseUIController
{
    public GameObject winPanel;

    public GameObject losePanel;

    public GameObject pausePanel;

    public Text bonusPerAimText, bonusPerFlipText;

    public int scenesOffsetToLevel1 = 2;

    public Text levelNumberLabel;

    private void Awake() {
        levelNumberLabel.text = (Application.loadedLevel - scenesOffsetToLevel1 + 1).ToString();   

        bonusPerAimText.gameObject.SetActive(false); 
        bonusPerFlipText.gameObject.SetActive(false);
    }

    private void Start() {
        Time.timeScale = 1;
    }
    
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void NextLevel()
    {
        if(Application.loadedLevel + 1 < Application.levelCount) {
            Application.LoadLevel(Application.loadedLevel + 1);
        } else {
            Application.LoadLevel(0);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    GameObject currentPanel;
    public void ShowWinPanel(float delay = 1.5f)
    {
        if(delay <= 0.1f){
            winPanel.SetActive(true);
            return;
        }

        currentPanel = winPanel;
        Invoke(nameof(ShowPanelWithPause), delay);
    }

    public void ShowLosePanel(float delay = 1.5f)
    {
        if(delay <= 0.1f){
            losePanel.SetActive(true);
            return;
        }

        currentPanel = losePanel;
        Invoke(nameof(ShowPanelWithPause), delay);
    }

    void ShowPanelWithPause(){
        if(currentPanel){
            currentPanel.SetActive(true);
        }
    }
}
