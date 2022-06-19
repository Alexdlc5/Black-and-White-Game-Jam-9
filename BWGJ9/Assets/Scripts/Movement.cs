using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float health = 10;

    //speeds
    public float speed;
    public float jump_height;
    public float sprinting_multiplier = 1.05f;
    //Components
    private Rigidbody2D rb;
    public Ground_Check check;
    //speed managment
    private float current_speed;
    private char previous_key = ' ';

    //tech installs
    //health
    public bool has_tech_a;
    public bool has_tech_b;
    public bool has_tech_c;
    public bool has_tech_d;
    public bool has_tech_e;

    public PlayerData player_data;
    private void Start()
    {
        has_tech_a = PlayerData.has_tech_a;
        if (has_tech_a)
        {
            health += 5;
        }
        has_tech_b = PlayerData.has_tech_b;
        has_tech_c = PlayerData.has_tech_c;
        has_tech_d = PlayerData.has_tech_d;
        has_tech_e = PlayerData.has_tech_e;
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0)
        {
            PlayerData.has_tech_a = has_tech_a;
            PlayerData.has_tech_b = has_tech_b;
            PlayerData.has_tech_c = has_tech_c;
            PlayerData.has_tech_d = has_tech_d;
            PlayerData.has_tech_e = has_tech_e;
            DontDestroyOnLoad(player_data);
            SceneManager.LoadScene("City");
        }

        //represents wheather or not player has hit horizontal movement key (HMI)
        bool horizontal_movement_inframe = false;
        
        bool shifting = false;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shifting = true;
        }
        //movement keys
        if (Input.GetKey(KeyCode.W))
        {
            //+transition out of crouch
        }
        if (Input.GetKey(KeyCode.A))
        {
            //sets HMI to true and adjusts speed
            horizontal_movement_inframe = true;
            if (previous_key == 'd' || previous_key == ' ')
            {
                if (current_speed / 4 < speed)
                {
                    if (shifting)
                    {
                        current_speed = speed * sprinting_multiplier;
                    }
                    else
                    {
                        current_speed = speed;
                    }
                }
                else
                {
                    if (shifting)
                    {
                        current_speed = (current_speed / 4) * sprinting_multiplier;
                    }
                    else
                    {
                        current_speed = current_speed / 4;
                    }
                }
                previous_key = 'a';
            }
            //moves in given direction
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
            transform.position = new Vector3(transform.position.x - current_speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            if (shifting)
            {
                current_speed = (current_speed + speed / 5) * sprinting_multiplier;
            }
            else
            {
                current_speed = (current_speed + speed / 5);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            //+crouch
            rb.AddForce(Vector2.down * current_speed / 2f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //represents wheather or not player has hit horizontal movement key (HMI)
            horizontal_movement_inframe = true;
            if (previous_key == 'a' || previous_key == ' ')
            {
                if (current_speed / 4 < speed)
                {
                    if (shifting)
                    {
                        current_speed = speed * sprinting_multiplier;
                    }
                    else
                    {
                        current_speed = speed;
                    }
                }
                else
                {
                    if (shifting)
                    {
                        current_speed = (current_speed / 4) * sprinting_multiplier;
                    }
                    else
                    {
                        current_speed = current_speed / 4;
                    }
                }
                previous_key = 'd';
            }
            //moves in given direction
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
            transform.position = new Vector3(transform.position.x + current_speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            if (shifting)
            {
                current_speed = (current_speed + speed / 5) * sprinting_multiplier;
            }
            else
            {
                current_speed = (current_speed + speed / 5);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //checks if player is on groud if so jump
            if (check.is_Touching_Ground)
            {
                rb.AddForce(Vector2.up * jump_height);
                check.is_Touching_Ground = false;
            }
        }
        //sets the previous key to none if no horizontal key pressed
        if (horizontal_movement_inframe == false)
        {
            previous_key = ' ';
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "TechPickupA")
        {
            has_tech_a = true;
        }
    }
}
