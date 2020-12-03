using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //indicates the speed of the player movement
    public float min_X, max_X; //indicates the min and max X value of the map
    public bool canControl = true;
    float move = 0f;

    public Animator anim;
    private AudioSource scream;

    void Awake()
    {
        anim = GetComponent<Animator>();
        scream = GetComponent<AudioSource>();
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", move);

        if (canControl) {
            MovePlayer();
        }
        if (Lives.lives <= 0)
        {
            Invoke("TurnOffGameObject", .7f);
            canControl = false;
        }
    }

    void MovePlayer() //allows the player to move up and down along the Y axis and not past the minimum or maximum Y values
    {
        if (Input.GetAxisRaw("Horizontal") > 0f) //allow the key input of the right arrow or D key
        {
            Vector2 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            SpeedUp();
            if (temp.x > max_X)
                temp.x = max_X;

            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)//allow the key input of the left arrow or A key
        {
            Vector2 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            SpeedUp();
            if (temp.x < min_X)
                temp.x = min_X;

            transform.position = temp;
        }
    }

    void SpeedUp()
    {
        if (FindObjectOfType<Timer>().currentTime >= 5 && FindObjectOfType<Timer>().currentTime < 10)
        {
            speed = 5.5f;
        }
        else if (FindObjectOfType<Timer>().currentTime >= 10 && FindObjectOfType<Timer>().currentTime < 15)
        {
            speed = 6;
        }
        else if (FindObjectOfType<Timer>().currentTime >= 15 && FindObjectOfType<Timer>().currentTime < 20)
        {
            speed = 6.5f;
        }
        else if (FindObjectOfType<Timer>().currentTime >= 20 && FindObjectOfType<Timer>().currentTime < 25)
        {
            speed = 7;
        }
        else if (FindObjectOfType<Timer>().currentTime >= 25 && FindObjectOfType<Timer>().currentTime < 30)
        {
            speed = 7.5f;
        }
        else if (FindObjectOfType<Timer>().currentTime >= 30 && FindObjectOfType<Timer>().currentTime < 35)
        {
            speed = 8;
        }
        else if (FindObjectOfType<Timer>().currentTime >= 35)
        {
            speed = 8.5f;
        }
    }
    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
    void Fiery()
    {
        anim.SetBool("IsFiery", true);
    }
    void NotFiery()
    {
        anim.SetBool("IsFiery", false);
    }
    void OnTriggerEnter2D(Collider2D target)//destroys the player and turns off the bullet on collision
    {
        if (target.tag == "Enemy")
        {
            Lives.lives -= 1;
            Invoke("Fiery", 0f);
            Invoke("NotFiery", .5f);
            scream.Play();
        }
    }
}