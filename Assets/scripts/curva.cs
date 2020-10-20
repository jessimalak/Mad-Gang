using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curva : MonoBehaviour
{
    private GameObject controller;
    private movimiento script;
    private player playerScript;
    private float rotateAngle = 90;
    [SerializeField]
    private bool right = true;
    [SerializeField]
    private Collider trigger, other1, other2;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        trigger = this.GetComponent<BoxCollider>();
        script = controller.GetComponent<movimiento>();
        playerScript = controller.GetComponentInChildren<player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        controller = col.gameObject;
        
        print(controller.tag);

        
        if (!playerScript.isTurning){
            playerScript.isTurning = true;       
            turnPlayer();
        }


        trigger.enabled = false;
        other1.enabled = false;
        other2.enabled = false;

        //Invoke("restartCol", 2);
        //player.transform.Rotate( 0, rotateAngle, 0, Space.World );
        //player.transform.rotation = Quaternion.Euler(0, rotateAngle, 0);
        //player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.Euler(0, rotateAngle, 0), 0.2f);

    }

    void restartCol()
    {
        trigger.enabled = false;
        other1.enabled = false;
        other2.enabled = false;
    }

    void turnPlayer()
    {
        if (right)
                {
                    rotateAngle = controller.transform.eulerAngles.y + 90;
                    if(rotateAngle > 359 )
                    {
                        rotateAngle = 0;
                    }
                }
        else
        {
            rotateAngle = controller.transform.eulerAngles.y - 90;
            if(rotateAngle < 0)
            {
                rotateAngle = 0;
            }
        }

                if(rotateAngle > 89 && rotateAngle < 91)
                {
                    rotateAngle = 90;
                }else if(rotateAngle > 269 && rotateAngle < 271)
                {
                    rotateAngle = 270;
                }

                script.angle = rotateAngle;
    }
}
