using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{
    public Text temporizadorTexto;
    [SerializeField] GameObject GameOverPanel;
    int temporizadorDuracao = 300;
    int temporizador = -1;

    private void Update()
    {
        ComecarTimer();
    }

    public void ComecarTimer()
    {
        if (temporizador == -1)
        {
            temporizador = temporizadorDuracao;
            InvokeRepeating("UpdateTimer", 0f, 1f);
        }
    }

    private void UpdateTimer()
    {
        if (temporizador > 0)
        {
            temporizador -= 1;
            UpdateTimerTexto();
        }
        else if (temporizador == 0)
        {
            Debug.Log("Tempo acabou!");
            CancelInvoke("UpdateTimer");
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
    }

    private void UpdateTimerTexto()
    {
        int minutes = temporizador / 60;
        int seconds = temporizador % 60;
        temporizadorTexto.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
