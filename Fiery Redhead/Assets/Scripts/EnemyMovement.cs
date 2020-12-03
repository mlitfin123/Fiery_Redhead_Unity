using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //speed of forward movement
    public float speed = 5f;

    //indicates enemy can move
    public bool canMove = true;
    //indicates the boundary of the game map
    public float bound_y = -15f;

    void Update()
    {
        Move();
        SpeedUp();
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

    void SpeedUp()
    {
        if (FindObjectOfType<Timer>().currentTime >= 5 && FindObjectOfType<Timer>().currentTime < 10)
        {
            speed = 7;
        }
        else if (FindObjectOfType<Timer>().currentTime >= 10 && FindObjectOfType<Timer>().currentTime < 15)
        {
            speed = 9;
        }
        else if (FindObjectOfType<Timer>().currentTime >= 15 && FindObjectOfType<Timer>().currentTime < 20)
        {
            speed = 11;
        }
        else if (FindObjectOfType<Timer>().currentTime >= 20 && FindObjectOfType<Timer>().currentTime < 25)
        {
            speed = 13;
        }
        else if (FindObjectOfType<Timer>().currentTime >= 25 && FindObjectOfType<Timer>().currentTime < 30)
        {
            speed = 15;
        }
        else if (FindObjectOfType<Timer>().currentTime >= 30 && FindObjectOfType<Timer>().currentTime < 35)
        {
            speed = 17;
        }
        else if (FindObjectOfType<Timer>().currentTime >= 35)
        {
            speed = 20;
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
            //destroy enemy
            Invoke("TurnOffGameObject", 0f);
        }
    }
}