
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Transform player;
    public Text speedText;

    void Update()
    {
        speedText.text = player.position.z.ToString(); 
    }
}
