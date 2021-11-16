using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheController : MonoBehaviour
{
    public GameObject cocheGO;
    public Camera cam;
    public float speed;
    public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= 8.5f && transform.position.x >= -8.5f)
        {
            transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);

            float zRot = Input.GetAxis("Horizontal") * -rotSpeed;
            cocheGO.transform.rotation = Quaternion.Euler(0, 0, zRot);
        }
        else if(transform.position.x > 8.5f)
        {
            transform.position = new Vector3(8.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.5f)
        {
            transform.position = new Vector3(-8.5f, transform.position.y, 0);
        }
    }
}
