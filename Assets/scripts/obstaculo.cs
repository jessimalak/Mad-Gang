using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculo : MonoBehaviour
{
    private player Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 9)
        {
            Player.points += 10;
        }
    }
}
