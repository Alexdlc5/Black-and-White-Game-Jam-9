using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Difficulty_Button : MonoBehaviour
{
    public static int difficulty = 0;
    public TextMeshProUGUI text;
    public Button button;

    private void Start()
    {
        text.text = "[DIFFICULTY] <Easy>";
        button.onClick.AddListener(toggleDifficulty);
    }

    void toggleDifficulty()
    {
        //toggles difficulty and UI
        if (difficulty == 0)
        {
            difficulty = 1;
            text.text = "[DIFFICULTY] <Normal>";
        }
        else if (difficulty == 1)
        {
            difficulty = 2;
            text.text = "[DIFFICULTY] <Hard>";
        }
        else
        {
            difficulty = 0;
            text.text = "[DIFFICULTY] <Easy>";
    
        }
    }
}
