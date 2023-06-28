using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Aviao : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] float velocidade;
    [SerializeField] GameObject GameOverPanel;
    bool morreu = false;
    [HideInInspector] public int derrotas = 0;
    [HideInInspector] public int pontos = 0;

    int hitCount = 3;

    enum MovementState { voando, atirando, morre }
    MovementState estado = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAnimations();

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * velocidade, Input.GetAxisRaw("Vertical") * velocidade);

        if (morreu == true)
        {
            Invoke("Revive", 2f);
            estado = MovementState.voando;
            morreu = false;
        }
    }

    void UpdateAnimations()
    {
        if(Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Vertical") > 0.1f)
        {
            estado = MovementState.voando;
        }

        else if (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Vertical") < -0.1f)
        {
            estado = MovementState.voando;
        }

        else if (Input.GetMouseButtonDown(0))
        {
            estado = MovementState.atirando;
        }

        if (morreu == true)
        {
            estado = MovementState.morre;
        }

        anim.SetInteger("estado", (int)estado);
    }

    void Revive()
    {
        if (morreu == true)
        {
            Time.timeScale = 1;
            rb.constraints = RigidbodyConstraints2D.None;
            morreu = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Objeto")
        {
            morreu = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Time.timeScale = 0;
            derrotas++;
            hitCount--;
        }

        if (hitCount <= 0)
        {
            Destroy(gameObject);
            GameOverPanel.SetActive(true);
        }
    }

    public void MudarPontos()
    {
        ;
    }
}
