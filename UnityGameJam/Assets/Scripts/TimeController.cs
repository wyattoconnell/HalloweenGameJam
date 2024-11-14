using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
