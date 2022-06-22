using UnityEngine;

public class Ground_Check : MonoBehaviour
{
    public bool is_Touching_Ground = true;
    public bool has_Exited_Ground = true;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());
        }
        else
        {
            is_Touching_Ground = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());
        } 
        else
        {
            is_Touching_Ground = false; has_Exited_Ground = true;
        }
    }
}
