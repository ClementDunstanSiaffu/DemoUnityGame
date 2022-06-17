
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public bool hasGameEnded = false;
    public float delayTimer = 1f;
    public GameObject completeUI;

    public void EndGame()
    {
        if (!hasGameEnded)
        {
            hasGameEnded = true;
            Invoke("restart", delayTimer);
        }
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void completeLevel()
    {
        completeUI.SetActive(true);
    }
}
