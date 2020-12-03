using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    bool endGame = false;
    public GameObject endGameText;

    // Start is called before the first frame update
    void Start()
    {
        endGame = false;
        Lives.lives = 3;
    }

    public void EndGame()
    {
        endGame = true; //sets the endGame boolean to true
        Invoke("End", 1.5f); //starts the End function
        endGameText.SetActive(true); //displays the endGame text
        Lives.lives = 0;
        FindObjectOfType<PlayFabManager>().SendLeaderboard(ScoreScript.Score);
    }
    void End()
    {
        SceneManager.LoadScene("Main Menu");  //redirects to the main menu when the game ends
    }
}
