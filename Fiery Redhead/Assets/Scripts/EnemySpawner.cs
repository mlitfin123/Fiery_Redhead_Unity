using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //indicates min and max spawn location
    public float min_x = -10f, max_x = 10f;

    //indicates enemies to spawn
    public GameObject[] enemy_Prefabs;

    //indicates time until next spawn
    public float timer = 2f;

    void Start()
    {
        Invoke("SpawnEnemies", timer);
    }
    void Update()
    {
        AdjustTime();
    }

    void SpawnEnemies()
    {
        //indicates a random position for the spawn between the min and max
        float pos_x = Random.Range(min_x, max_x);
        //temporary position of spawner
        Vector3 temp = transform.position;
        temp.x = pos_x;
        //spawn enemy
        Instantiate(enemy_Prefabs[Random.Range(0, enemy_Prefabs.Length)], temp, Quaternion.Euler(0f, 0f, 180f));
        
        Invoke("SpawnEnemies", timer);
    }
    void AdjustTime()
    {
        if (ScoreScript.Score >= 50 && ScoreScript.Score < 100)
        {
            timer = 0.8f;
        }
        else if (ScoreScript.Score >= 100 && ScoreScript.Score < 150)
        {
            timer = 0.6f;
        }
        else if (ScoreScript.Score >= 150 && ScoreScript.Score < 200)
        {
            timer = 0.5f;
        }
        else if (ScoreScript.Score >= 200 && ScoreScript.Score < 250)
        {
            timer = 0.4f;
        }
        else if (ScoreScript.Score >= 250 && ScoreScript.Score < 300)
        {
            timer = 0.3f;
        }
        else if (ScoreScript.Score >= 300 && ScoreScript.Score < 350)
        {
            timer = 0.2f;
        }
        else if (ScoreScript.Score >= 400)
        {
            timer = 0.1f;
        }
    }
}