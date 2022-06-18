using UnityEngine;

public class Window_Manager : MonoBehaviour
{
    public GameObject store;
    private bool StoreOpen = false;

    public GameObject pause;
    private bool PauseOpen = false;
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
            pause.SetActive(false);
            PauseOpen = false;
        }

    }
}

