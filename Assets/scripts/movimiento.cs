using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad = 10f;
    private GameObject player;
    private player playerScript;
    public float angle = 90;
    [SerializeField]
    private bool isNegative = false;
    [SerializeField]
    private bool isPlayer = false;
    private int direct = 1;
    [SerializeField]
    private float velocidadGiro = 0.2f;
    void Start()
    {
        if (isPlayer)
        {
            
            playerScript = GetComponentInChildren<player>();
        }
        if (isNegative)
        {
            direct = -1;
        }

    }

 
    void Update()
    { 
        transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, angle, 0), velocidadGiro * Time.deltaTime);
        if (isPlayer)
        {
            if(transform.localRotation.eulerAngles.y > angle - 1 && transform.localRotation.eulerAngles.y < angle + 1)
            {
                playerScript.isTurning = false;
            }
        }
        
       
        if (angle == 0)
        {
            transform.Translate(transform.right * -1 * direct * velocidad * Time.deltaTime, Space.Self);
        }
        else if (angle == 90)
        {
            transform.Translate(transform.forward *-1 * direct * velocidad * Time.deltaTime, Space.Self);
        }else if(angle == 180)
        {
            transform.Translate(transform.right * direct *velocidad * Time.deltaTime, Space.Self);
        }else if(angle == 270)
        {
            transform.Translate(transform.forward * direct * velocidad * Time.deltaTime, Space.Self);
        }else if(angle == 360)
        {
            transform.Translate(transform.right * -1 * direct * velocidad * Time.deltaTime, Space.Self);
        }
        
    }
    
}
