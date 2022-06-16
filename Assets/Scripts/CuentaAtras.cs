using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    public GameObject cocheControllerGO;
    public GameObject cocheGO;
    public MotorCarreteras motorCarreterasSC;
    public Sprite[] numbers;
    public SpriteRenderer numbersCountSR;
    // Start is called before the first frame update
    void Start()
    {
        Initialitation();
        Countdown();
    }

    void Initialitation()
    {
        cocheControllerGO = GameObject.Find("CocheController");
        cocheGO = GameObject.Find("Coche");
        motorCarreterasSC = GameObject.Find("MotorCarreteras").GetComponent<MotorCarreteras>();
        numbersCountSR = GameObject.Find("ContadorNumeros").GetComponent<SpriteRenderer>();
    }

    void Countdown()
    {
        StartCoroutine(Counting());
    }

    IEnumerator Counting()
    {
        cocheControllerGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        for(int i = 1; i <= 3; i++)
        {
            numbersCountSR.sprite = numbers[i];
            if (i < 3)
            {
                
                this.GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(1);
            }
            else
            {
                motorCarreterasSC.gameStart = true;
                numbersCountSR.gameObject.GetComponent<AudioSource>().Play();
                cocheGO.GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(1);
            }
        }

        numbersCountSR.gameObject.SetActive(false);
    }
}
