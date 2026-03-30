using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerctrl : MonoBehaviour
{

    private float fox_speed = 5.0f;
    private float rot_speed = 120.0f;
    float timePlay;
    float lock_move = 0.0f;
    bool passscene = false;


    float moving_velocity;
    float fox_angle;
    public Animator animator;
    int gameloop;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timePlay = PlayerPrefs.GetFloat("Playtime");
        gameloop = PlayerPrefs.GetInt("gameloop");

        

    }

    // Update is called once per frame
    void Update()
    {
        
        
        lock_move += Time.deltaTime;
        
        float distance_per_frame = fox_speed * Time.deltaTime;
        float degrees_per_frame = rot_speed * Time.deltaTime;
        
        if (lock_move > 2.0f)
        {
            timePlay += Time.deltaTime;
            moving_velocity = Input.GetAxis("Vertical");
            fox_angle = Input.GetAxis("Horizontal");
           
        }
        

        this.transform.Translate(Vector3.forward * moving_velocity * distance_per_frame);
        this.transform.Rotate(0.0f, fox_angle * degrees_per_frame, 0.0f);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            fox_speed = 10.0f;
            
        }
        else
        {
            fox_speed = 5.0f;
            
        }

        AnimationUpdate();
        
    }

    void AnimationUpdate()
    {
        if (moving_velocity == 0.0 && fox_angle == 0.0)
        {
            animator.SetBool("walk", false);
        }
        else
        {
            animator.SetBool("walk", true);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.gameObject.CompareTag("wall"))
        {
            PlayerPrefs.SetFloat("Playtime", timePlay);
            PlayerPrefs.SetInt("gameloop", 0);
            SceneManager.LoadScene("Crush_wall");
        }
        if (collision.collider.gameObject.CompareTag("trap"))
        {
            PlayerPrefs.SetFloat("Playtime", timePlay);
            PlayerPrefs.SetInt("gameloop", 0);
            SceneManager.LoadScene("Crush_trap");
        }
        if (collision.collider.gameObject.CompareTag("Finish"))
        {
            
            if (gameloop == 0)
            {
                
                SceneManager.LoadScene(Random.Range(1, 4));
                PlayerPrefs.SetInt("gameloop", 1);
                
            }
            else if (gameloop == 1)
            {
                
                SceneManager.LoadScene(Random.Range(1, 4));
                PlayerPrefs.SetInt("gameloop", 2);

            }
            
            else if( gameloop ==2)
            {
                SceneManager.LoadScene("success");
            }


        }

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(20, Screen.height - 40, 128, 32), "Playtime:");
        GUI.Label(new Rect(105, Screen.height - 40, 128, 32), timePlay.ToString());
    }
}



