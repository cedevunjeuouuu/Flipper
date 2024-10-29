using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
  
    [SerializeField] Color badColor = Color.red;
    [SerializeField] Color neutralColor = Color.yellow;
    [SerializeField] Color goodColor = Color.cyan;

    [SerializeField] float badValue     = 50;
    [SerializeField] float neutralValue = 60;
  
    [SerializeField] float fps;
  
    const float updateInterval = .1f;
  
    float                  accum;
    float                  frames;
    float                  timeLeft;
  
    void Update()
    {
        timeLeft -= Time.deltaTime;
        accum    += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeLeft <= 0)
        {
            fps = accum / frames;
              
            if (fps < badValue)
            {
                text.color = badColor;
            }
            else if(fps < neutralValue )
            {
                text.color = neutralColor;
            }
            else
            {
                text.color = goodColor;
            }

            text.text = fps.ToString("f1");
            timeLeft  = updateInterval;
            accum     = 0;
            frames    = 0;
        }
    }
}