using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsController : MonoBehaviour
{
    public BaseUIController ui;

    public GameObject levelsPanel;

    public List<GameObject> levels, padlocks;

    private int current;

    public int scenesOffsetToLevel1 = 2, numberOfLevels = 12;

    void Start(){
        SetLevelsPanelActive(false);
        current = PlayerPrefs.GetInt("level", 0) >= numberOfLevels ? numberOfLevels-1 : PlayerPrefs.GetInt("level", 0);

        Show(current);
    }

    public void Left(){
        current--;

        if(current < 0){
            current = levels.Count - 1;
        }

        Show(current);
    }

    public void Right(){
        current++;

        if(current > levels.Count - 1){
            current = 0;
        }

        Show(current);
    }

    void Show(int n){
        HideAll();

        levels[n].SetActive(true);

        padlocks[n].SetActive(PlayerPrefs.GetInt("level", 0) < n);
    }

    void HideAll(){
        foreach(var level in levels)level.SetActive(false);

        foreach(var padlock in padlocks)padlock.SetActive(false);
    }

    public void OpenLevel(){
        if(!padlocks[current].activeSelf){
            ui.OpenScene(current+scenesOffsetToLevel1);
        }
    }

    public void SetLevelsPanelActive(bool active){
        levelsPanel.SetActive(active);
    }
}
