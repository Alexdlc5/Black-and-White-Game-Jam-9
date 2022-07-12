using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Final_Time : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Update()
    {
        //                          I'm not changing this
        GetComponent<TextMeshProUGUI>().text = text.text; 
    }
}
