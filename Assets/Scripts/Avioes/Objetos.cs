using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    [SerializeField] float velocidade;

    private void Update()
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
