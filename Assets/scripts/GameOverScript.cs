
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameManagerScript gameManger;
    void OnTriggerEnter()
    {
        this.gameManger.hasGameEnded = true;
        gameManger.completeLevel();
    }
}
