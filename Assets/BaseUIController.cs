using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIController : MonoBehaviour
{
    public GameObject loadingPanel;

    private void Start() {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));
    }
    public void OpenScene(int id){
        Time.timeScale = 1;
        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(id);
    }
}
