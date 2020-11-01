using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipe : MonoBehaviour
{
    private float posX1, posX2, distance;
    //public float left, center, right;
    public float velocidad = 3f;
    public GameObject car, left, center, right, target, actual;
    private int position, direction;
    private Vector3 look;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            posX1 = Input.mousePosition.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            posX2 = Input.mousePosition.x;
            distance = posX1 - posX2;
            if (posX1 < posX2 && distance < -75)
        {
           
            direction = 1;
            if (position == 0)
            {
                position = 1;
            }
            else if (position == -1)
            {
                position = 0;
            }
        }
        else if(posX1 > posX2 && distance > 75)
        {
           
            direction = -1;
            if (position == 0)
            {
                position = -1;
            }
            else if (position == 1)
            {
                position = 0;
            }
        }
        //else
        //{
        //    texto.text = "hagale con ganas";
        //}
        }

        if(car.transform.eulerAngles.y == 0 || car.transform.eulerAngles.y == 360 || car.transform.eulerAngles.y == 180)
        {
            look = transform.forward;
        }else if(car.transform.eulerAngles.y == 90 || car.transform.eulerAngles.y == 270)
        {
            look = transform.right;
        }


        switch (position)
        {
            case 0:
                if (target != center)
                    transform.Translate(look * direction * velocidad * Time.deltaTime, Space.Self);
                break;
            case 1:
                if(target != right)
                    transform.Translate(look * direction * velocidad * Time.deltaTime, Space.Self);
                break;
            case -1:
                if(target != left)
                    transform.Translate(look * direction * velocidad * Time.deltaTime, Space.Self);
                break;
        }
       
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 9)
        {
            StartCoroutine(updateTarget(col.gameObject));
        }
        //else
        //{
        //    Debug.Log("curvita");
        //}
        
    }

    IEnumerator updateTarget(GameObject limiter)
    {
        yield return new WaitForSeconds(1);
        target = limiter;
        StopAllCoroutines();
    }
}
