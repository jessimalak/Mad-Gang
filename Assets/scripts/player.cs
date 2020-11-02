using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour
{
    public bool isTurning = false;
    public int points = 0;
    private swipe swipe_script;
    private movimiento move_script;
    private int losePoints = 0;
    
    [Header("UI")]
    public Image background;
    public GameObject loseScreen, finishScreen, rewardButton;
    public Text counter, finishLabel, deadLabel, rewardText;
    [Header("Ads")]
    [SerializeField]
    private adManager manager;
    private bool loadedAd = false;

    void Start()
    {
        swipe_script = GetComponent<swipe>();
        move_script = GetComponentInParent<movimiento>();
        Time.timeScale = 2f;
        points = PlayerPrefs.GetInt("losePoints");
        Debug.Log(PlayerPrefs.GetInt("random"));
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
        if(points > 0)
        {
            losePoints = (points / 3) * -1;
        if (!loadedAd)
            {
                manager.RequestReward();
                rewardButton.SetActive(true);
                loadedAd = true;
            }
        }

       
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Finish")
        {
            PlayerPrefs.SetInt("losePoints", 0);
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
                PlayerPrefs.SetInt("losePoints", losePoints);
                int puntos = losePoints * -1;
                deadLabel.text = "Chocaste\nPerdiste " + puntos + " puntos";
                int recuperables = puntos / 2;
                rewardText.text = "Recuperar " + recuperables + " puntos";
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
