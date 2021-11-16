using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotorCarreteras : MonoBehaviour
{
    public float speed;
    public float calleSize;
    public bool gameStart;
    public bool gameEnded;
    public bool outOfBounds;

    public GameObject callesContainerGO;
    public GameObject calleNew;
    public GameObject calleOld;
    public GameObject cocheGO;
    public GameObject gameOverGO;
    public GameObject[] callesContainerArray;
    public Camera cam;
    public Vector3 screenBounds;
    public AudioFX audioFXSC;
    

    int countCalles = 0;
    int calleNumber;


    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart && !gameEnded)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if ((calleOld.transform.position.y + calleSize) < screenBounds.y && !outOfBounds)
            {
                outOfBounds = true;
                DestroyCalles();
            }
        }    
    }
    void GameStart()
    {
        callesContainerGO = GameObject.Find("ContenedorCalles");
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        audioFXSC = GameObject.FindObjectOfType<AudioFX>();
        cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;
        gameOverGO = GameObject.Find("GameOverPanel");
        gameOverGO.SetActive(false);
        
        MotorSpeed();
        MeasureScreen();
        FindCalles();
    }

    void MotorSpeed()
    {
        speed = 10;
    }

    void FindCalles()
    {
        callesContainerArray = GameObject.FindGameObjectsWithTag("Calle");
        for(int i = 0; i < callesContainerArray.Length; i++)
        {
            callesContainerArray[i].gameObject.transform.parent = callesContainerGO.transform;
            callesContainerArray[i].gameObject.SetActive(false);
            callesContainerArray[i].gameObject.name = "CalleOFF_" + i;
        }
        CreateCalles();
    }

    void CreateCalles()
    {
        countCalles++;
        calleNumber = Random.Range(0, callesContainerArray.Length);
        GameObject calle = Instantiate(callesContainerArray[calleNumber]);
        calle.SetActive(true);
        calle.name = "Calle_" + countCalles;
        calle.transform.parent = gameObject.transform;
        CallePosition();
    }

    void CallePosition()
    {
        calleOld = GameObject.Find("Calle_" + (countCalles - 1));
        calleNew = GameObject.Find("Calle_" + countCalles);
        MeasureCalle();
        calleNew.transform.position = new Vector3(calleOld.transform.position.x, calleOld.transform.position.y + calleSize, 0f);
        outOfBounds = false;
    }

    void MeasureCalle()
    {
        for(int i = 0; i < calleOld.transform.childCount; i++)
        {
            if(calleOld.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
                float piezaSize = calleOld.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                calleSize += piezaSize;
            }
        }
    }

    void MeasureScreen()
    {
        screenBounds = new Vector3(0, cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);
    }

    void DestroyCalles()
    {
        Destroy(calleOld);
        calleSize = 0;
        calleOld = null;
        CreateCalles();
    }

    public void GameOver()
    {
        cocheGO.GetComponent<AudioSource>().Stop();
        audioFXSC.GameOverMusic();
        gameOverGO.SetActive(true);
    }
}
