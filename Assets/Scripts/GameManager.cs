using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1.5f;

    public GameObject completeLevelUI;

    public static bool disableInput = false;
    public void CompleteLevel() {
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
