using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{

    [SerializeField] LevarNaveAoPlaneta levar;

    [Header("Telas do jogo MORTE/VENCEU")]
    [SerializeField] GameObject telaGameOver;
    [SerializeField] GameObject telaDeJogoVencido;

    [Header("Pontuação do jogador")]
    [SerializeField] private Text txtPontuacao;
    [SerializeField] private float divisorDaPontuacao;

    [Header("Script do jogador")]
    [SerializeField] private PlayerController player;

    [Header("Prefab de explosão do jogador")]
    [SerializeField] private GameObject explosionJogadorPreafab;

    Vector3 posInicial;
    AudioController audioController;
    // Start is called before the first frame update
    void Start()
    {
        
        telaGameOver.SetActive(false);
        telaDeJogoVencido.SetActive(false);

        if(divisorDaPontuacao <= 0)
        {
            divisorDaPontuacao = 1;
        }
        posInicial = player.transform.position;

        audioController = GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    { 
        calcularDistanciaPercorrida();
        tocarMusica();
    }

    public bool verificarSeTelaGameOverOuTelaVenceuEstaAtivada()
    {
        if(telaDeJogoVencido.activeSelf || telaGameOver.activeSelf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void calcularDistanciaPercorrida()
    {
        if (verificarComponentesDoJogador())
        {
            return;
        }

        Vector3 distanciaPercorrida = player.transform.position - posInicial;
        float pontuacao = distanciaPercorrida.z / divisorDaPontuacao;
        setTextPotuacao(pontuacao);
    }
    void setTextPotuacao(float pontuacao)
    {
        txtPontuacao.text = pontuacao.ToString("0");
    }
    public void gameOver()
    {
        audioController.tocarAudio(audioController.sonsEfeitos[0]);
        Destroy(player.gameObject);
        GameObject.Instantiate(explosionJogadorPreafab, player.transform.position, player.transform.rotation);
        telaGameOver.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameWins()
    {
        audioController.tocarAudio(audioController.sonsEfeitos[1]);
        levar.levarPlayerAoPlaneta();
        telaDeJogoVencido.SetActive(true);
    }

    //public void pausarJogo(bool parar)
    //{
    //    Time.timeScale = (parar) ? 0 : 1; 
    //}

    public bool verificarComponentesDoJogador()
    {
        if(player == null)
        {
            return true;
        }

        return false;
    }

    void tocarMusica()
    {
        if (!audioController.vericarSeAudioEstaTocando())
        {
            audioController.tocarAudio(audioController.sonsBackground[UnityEngine.Random.Range(0, audioController.sonsBackground.Length)], 0.320f);
        }
    }
}
