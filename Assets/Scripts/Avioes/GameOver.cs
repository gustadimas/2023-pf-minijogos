using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text totalPontos, totalDerrotas;

    private void Update()
    {
        totalPontos.text = "Pontos: " + GetComponent<Aviao>().pontos;
        totalDerrotas.text = "Derrotas: " + GetComponent<Aviao>().derrotas;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
