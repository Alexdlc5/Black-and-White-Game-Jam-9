using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer = 0;

    //when new scene loaded update stats
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "City")
        {

            timer = PlayerData.time;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int Min = (int)timer / 60;
        int Sec = (int)timer % 60;
        string timerString = Min + "m " + Sec + "s"; 
        GetComponent<TextMeshProUGUI>().text = timerString;
    }
}
