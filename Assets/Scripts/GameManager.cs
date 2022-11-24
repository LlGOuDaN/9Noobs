using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int lastLevel = 5;
    bool gameHasEnded = false;

    public float restartDelay = 1.5f;

    public GameObject completeLevelUI;
    public GameObject starRatingUI;

    public static bool disableInput = false;
    public static bool disbaleRespawn = true;

    int score = 0;
    public void CompleteLevel() {
        disableInput = true;

        //score = FindObjectOfType<ScoreManager>().GetScore();
        Debug.Log("Level Score:" + score.ToString());
        completeLevelUI.SetActive(true);
        starRatingUI.SetActive(true);
        Invoke("SetStars", 0.5f);
    }

    public void EndGame() {
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }

    }

    public bool isEnd() {
        return gameHasEnded;
    }

    void Restart() {
        Debug.Log("Restart in GameManager");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SetStars() {
        FindObjectOfType<StarHandler>().StarsAcheived();
    }
}
