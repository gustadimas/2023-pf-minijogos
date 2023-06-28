using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] GameObject arma, bala;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Instantiate(bala, new Vector2(arma.transform.position.x, arma.transform.position.y), arma.transform.rotation);
    }
}
