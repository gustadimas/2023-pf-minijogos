using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField] InputField usuarioField;
    [SerializeField] InputField senhaField;
    [SerializeField] Text geralTexto;
    int numUsuariosMax = 2;

    Dictionary<string, string> usuarios = new Dictionary<string, string>();

    public void ValidarLogin()
    {
        string login = usuarioField.text;
        string senha = senhaField.text;

        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
        {
            geralTexto.text = "Os campos de usuário e senha não podem ficar em branco.";
            Invoke("CadastroFeito", 1.5f);
            return;
        }

        if (usuarios.ContainsKey(login))
        {
            if (usuarios[login] == login)
            {
                print("Usuario ja cadastro");
                geralTexto.text = "Login bem sucedido!";
                Invoke("ProximaCena", 1.5f);
            }
            else
            {
                geralTexto.text = "Senha incorreta!";
            }
        }
        else
        {
            try
            {
                if (usuarios.Count < numUsuariosMax)
                {
                    usuarios.Add(login, senha);
                    geralTexto.text = "Usuário cadastrado com sucesso";
                    Invoke("CadastroFeito", 1f);
                }
                else
                {
                    throw new System.Exception("Limite de contas de usuários atingido!");
                }
            }
            catch (System.Exception e)
            {
                geralTexto.text = "Erro ao cadastrar usuário: " + e.Message;
                Invoke("RealizarLogin", 2f);
            }
        }
    }

    void ProximaCena()
    {
        SceneManager.LoadScene("Dinossauro");
    }

    void CadastroFeito()
    {
        geralTexto.text = "Faça o registro!";
        usuarioField.text = "";
        senhaField.text = "";
    }

    void RealizarLogin()
    {
        geralTexto.text = "Realize o Login!";
        usuarioField.text = "";
        senhaField.text = "";
    }
}