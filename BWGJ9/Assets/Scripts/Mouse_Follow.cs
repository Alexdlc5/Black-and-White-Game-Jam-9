using UnityEngine;

public class Mouse_Follow : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(new Vector3(worldPosition.x, worldPosition.y, transform.position.z));
        //transform.position = player.position;
    }
}
