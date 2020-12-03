using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    private float startingTime = 0f;

    void Start() // Start the timer 
    {
        currentTime = startingTime;
    }
    void Update() //updates and displays the timer according to real time
    {
        currentTime += Time.deltaTime;

        if (currentTime <= 0)
            currentTime = 0;
    }
}
