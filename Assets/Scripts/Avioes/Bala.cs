using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float velocidade;

    private void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Objeto"))
        {
            Destroy(collision.gameObject);
            GetComponent<Aviao>().MudarPontos();
        }
    }
}
