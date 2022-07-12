using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Win_Screen : MonoBehaviour
{
    public GameObject window;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            Time.timeScale = 0;
            window.SetActive(true);
        }
    }
}
