using UnityEngine;

public class ChocolateMovement : MonoBehaviour
{
    //speed of forward movement
    public float speed = 5f;

    //indicates enemy can move
    public bool canMove = true;
    //indicates the boundary of the game map
    public float bound_y = -15f;

    private Animator anim;
    private AudioSource explosionSound;
    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        Move();
        if (Lives.lives <= 0)
        {
            Invoke("TurnOffGameObject", 0f);
        }
    }

    void Move()
    {
        if (canMove)
        {
            //enemies move forward after spawning
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            transform.position = temp;
            //remove game object after hitting the boundary
            if (temp.y < bound_y)
                gameObject.SetActive(false);
        }
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
    //determines the actions on collision
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            //add score
            ScoreScript.Score += 50;
            //destroy enemy
            Invoke("TurnOffGameObject", 0f);
        }
    }
}