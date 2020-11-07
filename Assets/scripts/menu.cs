using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
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
    public void OcultarTienda()
    {
        tiendaUi.SetActive(false);
    }
    public void OcultarFinish()
    {
        finishScreen.SetActive(false);
    }
    public void MostrarFinish()
    {
        finishScreen.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
