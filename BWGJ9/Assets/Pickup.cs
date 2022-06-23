using UnityEngine;
using UnityEngine.SceneManagement;
public class Pickup : MonoBehaviour
{
    public Movement player;
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

            if (player.has_tech_a && name == "TechPickupA")
            {
                gameObject.SetActive(false);
            }
            if (player.has_tech_b && name == "TechPickupB")
            {
                gameObject.SetActive(false);
            }
            if (player.has_tech_c && name == "TechPickupC")
            {
                gameObject.SetActive(false);
            }
            if (player.has_tech_d && name == "TechPickupD")
            {
                gameObject.SetActive(false);
            }
            if ( player.has_tech_e && name == "TechPickupE")
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
