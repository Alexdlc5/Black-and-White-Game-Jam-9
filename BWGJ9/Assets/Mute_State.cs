using UnityEngine;

public class Mute_State : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioListener>().enabled = !Mute_Button.muted;
    }
}
