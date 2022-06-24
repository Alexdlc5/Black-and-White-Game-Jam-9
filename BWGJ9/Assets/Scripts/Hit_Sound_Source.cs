using UnityEngine;

public class Hit_Sound_Source : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
