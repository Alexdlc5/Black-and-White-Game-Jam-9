using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float health = 2;
    public int difficulty;
    //speeds
    public float speed;
    public float jump_height;
    public float max_speed;
    public float sprinting_multiplier = 1.05f;
    //Components
    private Rigidbody2D rb;
    public Ground_Check check;
    //speed managment
    private float current_speed;
    private char previous_key = ' ';
    //tech installs
    public bool has_tech_a;
    public bool has_tech_b;
    public bool has_tech_c;
    public bool has_tech_d;
    public bool has_tech_e;
    //saved player data
    public PlayerData player_data;
    //animation
    public Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //sets up animator
        animator = GetComponent<Animator>();

        //sets player upgrades
        setPlayerStats();
    }
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

            setPlayerStats();
            //sets difficulty
            setDifficulty();
            check.has_Exited_Ground = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //if falling or jumping play jump anim 
        animator.SetBool("Movement_Y", !check.is_Touching_Ground);

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
            //sets running anim
            animator.SetBool("Movement_X", true);

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
                        current_speed = (current_speed / 1.5f) * sprinting_multiplier;
                    }
                    else
                    {
                        current_speed = current_speed / 1.5f;
                    }
                }
                previous_key = 'a';
            }
            //moves in given direction
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
            if (current_speed >= max_speed)
            {
                transform.position = new Vector3(transform.position.x - max_speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - current_speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            }
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
            //sets running anim
            animator.SetBool("Movement_X", true);
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
                        current_speed = (current_speed / 1.5f) * sprinting_multiplier;
                    }
                    else
                    {
                        current_speed = current_speed / 1.5f;
                    }
                }
                previous_key = 'd';
            }
            //moves in given direction
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
            if (current_speed >= max_speed)
            {
                transform.position = new Vector3(transform.position.x + max_speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + current_speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            }
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
            //checks if player is on ground if so jump
            if (check.is_Touching_Ground && check.has_Exited_Ground)
            {
                GetComponent<AudioSource>().Play();
                rb.AddForce(Vector2.up * jump_height);
                check.is_Touching_Ground = false;
                check.has_Exited_Ground = false;
            }
            else if (!check.has_Exited_Ground)
            {
                check.has_Exited_Ground = true;
            }
        }
        //sets the previous key to none if no horizontal key pressed
        if (horizontal_movement_inframe == false)
        {
            previous_key = ' ';
        }
        //sets idle anim
        if (!horizontal_movement_inframe)
        {
            animator.SetBool("Movement_X", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "TechPickupA")
        {
            has_tech_a = true;
        }
        if (collision.gameObject.name == "TechPickupB")
        {
            has_tech_b = true;
        }
        if (collision.gameObject.name == "TechPickupC")
        {
            has_tech_c = true;
        }
        if (collision.gameObject.name == "TechPickupD")
        {
            has_tech_d = true;
        }
        if (collision.gameObject.name == "TechPickupE")
        {
            has_tech_e = true;
        }
    }

    private void setPlayerStats()
    {
        //sets player upgrades
        has_tech_a = PlayerData.has_tech_a;
        if (has_tech_a)
        {
            max_speed += 1;
            health += 2;
        }
        has_tech_b = PlayerData.has_tech_b;
        if (has_tech_b)
        {
            max_speed += 1;
            jump_height += 25;
            health += 1;
        }
        has_tech_c = PlayerData.has_tech_c;
        if (has_tech_c)
        {
            max_speed += 1;
            health += 2;
        }
        has_tech_d = PlayerData.has_tech_d;
        if (has_tech_d)
        {
            max_speed += 1;
            jump_height += 25;
            health += 1;
        }
        has_tech_e = PlayerData.has_tech_e;
        if (has_tech_e)
        {
            max_speed += 1;
            jump_height += 25;
            health += 3;
        }
    }

    private void setDifficulty()
    {
        difficulty = Difficulty_Button.difficulty;
        if (difficulty == 0)
        {
            health += 3;
        }
        else if (difficulty == 1)
        {
            health += 0;
        }
        else
        {
            health -= 1;
        }
    }
}
