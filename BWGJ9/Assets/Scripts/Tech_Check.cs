using UnityEngine;
using UnityEngine.SceneManagement;

public class Tech_Check : MonoBehaviour
{
    public GameObject TechA;
    public GameObject TechB;
    public GameObject TechC;
    public GameObject TechD;
    public GameObject TechE;
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
            if (PlayerData.has_tech_a)
            { 
                TechA.SetActive(true);
            }
            if (PlayerData.has_tech_b)
            {
                TechB.SetActive(true);
            }
            if (PlayerData.has_tech_c)
            {
                TechC.SetActive(true);
            }
            if (PlayerData.has_tech_d)
            {
                TechD.SetActive(true);
            }
            if (PlayerData.has_tech_e)
            {
                TechE.SetActive(true);
            }
        }
    }
}
