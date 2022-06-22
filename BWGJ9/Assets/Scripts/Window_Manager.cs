using UnityEngine;
using UnityEngine.UI;

public class Window_Manager : MonoBehaviour
{
    public GameObject store;
    private bool StoreOpen = false;

    public GameObject pause;
    public Button resumebutton_P;
    private bool PauseOpen = false;

    private void Start()
    {
        resumebutton_P.onClick.AddListener(closePause);
    }
    // Update is called once per frame
    void Update()
    {
        if (!PauseOpen && !StoreOpen && Input.GetKeyDown(KeyCode.E))
        {
            store.SetActive(true);
            StoreOpen = true;
        }
        else if (!PauseOpen && !StoreOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pause.SetActive(true);
            PauseOpen = true;
        }
        else if (StoreOpen && !PauseOpen && Input.GetKeyDown(KeyCode.E))
        {
            store.SetActive(false);
            StoreOpen = false;
        }
        else if (!StoreOpen && PauseOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            pause.SetActive(false);
            PauseOpen = false;
        }

    }

    void closePause()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        PauseOpen = false;
    }
}

