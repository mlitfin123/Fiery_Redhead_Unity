using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    //indicates min and max spawn location
    public float min_x = -10f, max_x = 10f;

    //indicates bonus to spawn
    public GameObject[] bonus_Prefabs;

    //indicates time until next spawn
    public float timer = 2f;

    void Start()
    {
        Invoke("SpawnBonus", timer);
    }

    void SpawnBonus()
    {
        //indicates a random position for the spawn between the min and max
        float pos_x = Random.Range(min_x, max_x);
        //temporary position of spawner
        Vector3 temp = transform.position;
        temp.x = pos_x;
        //spawn the bonus
        Instantiate(bonus_Prefabs[Random.Range(0, bonus_Prefabs.Length)], temp, Quaternion.identity);

        Invoke("SpawnBonus", timer);
    }
}