using UnityEngine;
using UnityEngine.SceneManagement;
public class Pickup : MonoBehaviour
{
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
            if (PlayerData.has_tech_a && name.Equals("TechPickupA"))
            {
                gameObject.SetActive(false);
            }
            else if (PlayerData.has_tech_b && name.Equals("TechPickupB"))
            {
                gameObject.SetActive(false);
            }
            else if (PlayerData.has_tech_c && name.Equals("TechPickupC"))
            {
                gameObject.SetActive(false);
            }
            else if (PlayerData.has_tech_d && name.Equals("TechPickupD"))
            {
                gameObject.SetActive(false);
            }
            else if (PlayerData.has_tech_e && name.Equals("TechPickupE"))
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {     
            GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
