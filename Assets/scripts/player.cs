using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public GameObject loseScreen, finishScreen;
    public Image background;
    private swipe swipe_script;
    private movimiento move_script;
    public bool isTurning = false;
    public int points = 0;
    public Text counter, finishLabel;

    void Start()
    {
        swipe_script = GetComponent<swipe>();
        move_script = GetComponentInParent<movimiento>();
        Time.timeScale = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTurning)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = true;
        }

        counter.text = points.ToString();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Finish")
        {
            
            finishScreen.SetActive(true);
            finishLabel.text = "Ganaste\n Obtuviste " + points + " puntos";
            swipe_script.enabled = false;
            Time.timeScale = 1f;
            StartCoroutine(ShowBackground());
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstaculo")
        {
            if(!isTurning){ 
                loseScreen.SetActive(true);
                swipe_script.enabled = false;
                move_script.enabled = false;
                Time.timeScale = 1f;
                StartCoroutine(ShowBackground());
            }
            
        }
    }

    IEnumerator ShowBackground()
    {
        yield return new WaitForSeconds(3);
        background.enabled = true;
        StopAllCoroutines();
    }
}
