using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public float time;
    public float distance;

    public MotorCarreteras motorCarreterasSC;
    public Text timeText;
    public Text distanceText;
    public Text gameOverDistance;
    // Start is called before the first frame update
    void Start()
    {
        motorCarreterasSC = GameObject.Find("MotorCarreteras").GetComponent<MotorCarreteras>();
        timeText = GameObject.Find("Tiempo").GetComponent<Text>();
        distanceText = GameObject.Find("Distancia").GetComponent<Text>();
        //gameOverDistance = GameObject.Find("DistanciaFinalText").GetComponent<Text>();

        timeText.text = "0:10";
        distanceText.text = "0m";
        time = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(motorCarreterasSC.gameStart && !motorCarreterasSC.gameEnded)
            CalculateTimeDistance();
        if (time <= 0 && !motorCarreterasSC.gameEnded)
        {
            motorCarreterasSC.gameEnded = true;
            motorCarreterasSC.GameOver();
            gameOverDistance.text = distanceText.text;
            timeText.text = "0:00";
        }
            
    }

    void CalculateTimeDistance()
    {
        distance += Time.deltaTime * motorCarreterasSC.speed;
        distanceText.text = ((int)distance).ToString() + "m";

        time -= Time.deltaTime;
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        timeText.text = minutes.ToString() + ":" + seconds.ToString().PadLeft(2, '0');
    }
}
