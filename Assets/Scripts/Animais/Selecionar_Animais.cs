using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selecionar_Animais : MonoBehaviour
{
    [SerializeField] GameObject lobo, alce, arara, penguim, porco, coruja;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.gameObject.name == "Lobo")
            {
                AudioManager.instance.Play("Lobo");
                Debug.Log(hit.collider.name);
            }

            if (hit.collider.gameObject.name == "Alce")
            {
                AudioManager.instance.Play("Alce");
                Debug.Log(hit.collider.name);
            }

            if (hit.collider.gameObject.name == "Arara")
            {
                AudioManager.instance.Play("Arara");
                Debug.Log(hit.collider.name);
            }

            if (hit.collider.gameObject.name == "Penguim")
            {
                AudioManager.instance.Play("Penguim");
                Debug.Log(hit.collider.name);
            }

            if (hit.collider.gameObject.name == "Porco")
            {
                AudioManager.instance.Play("Porco");
                Debug.Log(hit.collider.name);
            }

            if (hit.collider.gameObject.name == "Coruja")
            {
                AudioManager.instance.Play("Coruja");
                Debug.Log(hit.collider.name);
            }
        }
    }
}
