using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health_Bar : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().maxValue = player.GetComponent<Movement>().maxhealth;
        GetComponent<Slider>().value = player.GetComponent<Movement>().health;
    }
}
