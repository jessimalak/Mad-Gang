using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tienda : MonoBehaviour
{
    [Header("lista de items vendidos")]
    [SerializeField] private ItemTienda[] Itemtienda;

    [Header("Referencias")]
    [SerializeField] private Transform contenedor;
    [SerializeField] private GameObject prefabitems;

    private void Start()
    {
        CreateItems();
    }


    public void CreateItems()
    {
        foreach(ItemTienda item in Itemtienda)
        {
            Item shopItem = Instantiate(prefabitems, contenedor).transform.GetComponent<Item>();
            shopItem.itemImage.sprite = item.sprite;
        }
    }
}

