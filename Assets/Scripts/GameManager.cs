using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int lastLevel = 5;
    bool gameHasEnded = false;

    public float restartDelay = 1.5f;

    public GameObject completeLevelUI;

    public static bool disableInput = false;
    public static bool disbaleRespawn = true;
    public void CompleteLevel() {
        disableInput = true;
        completeLevelUI.SetActive(true);
    }

    public void EndGame() {
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }

    }

    void Restart() {
        Debug.Log("I am here");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
