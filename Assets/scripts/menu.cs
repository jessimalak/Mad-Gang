using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject loseScreen, finishScreen;

    [Header("Tienda")]
    public GameObject tiendaUi;

    [Header("Gold UI")]
    public Text goldText;

    private void Start()
    {
        tiendaUi.SetActive(false);
    }

    public void SetGold(int gold)
    {
        goldText.text = "$" + gold;
    }

    public void MostrarTienda()
    {
        tiendaUi.SetActive(true);
    }

    public void Retry()
    {
        //loseScreen.SetActive(false);
        //finisgScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
