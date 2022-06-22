using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Mute_Button : MonoBehaviour
{
    public static bool muted = false;
    public Button button;
    public TextMeshProUGUI text;

    private void Start()
    {
        button.onClick.AddListener(mutetoggle);
    }

    void mutetoggle()
    {
        muted = !muted;
        text.text = "[MUTE] <" + muted + ">";
    }
}
