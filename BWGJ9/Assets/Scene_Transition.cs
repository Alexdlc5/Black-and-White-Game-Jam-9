using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Scene_Transition : MonoBehaviour
{
    public Button button;
    public string SceneToLoad;

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(LoadNewScene);
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene(SceneToLoad);
        Time.timeScale = 1;
    }
}
