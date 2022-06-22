using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit_Game : MonoBehaviour
{
    public Button button;
    void Update()
    {
        button.onClick.AddListener(Exit);
    }
    void Exit()
    {
        Application.Quit();
    }
}
