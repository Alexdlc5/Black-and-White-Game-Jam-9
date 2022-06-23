using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Scene_Transition : MonoBehaviour
{
    public bool isPlayButton = false;
    public GameObject loadingScreen;
    public Button button;
    public string SceneToLoad;

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(LoadNewScene);
    }

    void LoadNewScene()
    {
        if (isPlayButton)
        {
            loadingScreen.SetActive(true);
        }
        SceneManager.LoadScene(SceneToLoad);
        Time.timeScale = 1;
    }
}
