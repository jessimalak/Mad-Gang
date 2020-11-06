using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Button itemButton;
    public Image itemImage;
    public int value;

    void Start()
    {
        itemButton.onClick.AddListener(BuyItem);
    }
    public void BuyItem()
    {
        var player = GameObject.FindObjectOfType<player>();
        if (player.oroActual >= value)
        {
          Destroy(gameObject);
          player.oroActual -= value;
        }
        else
        {
            Debug.Log("no tienes suficiente dinero!");
        }
    }
}
