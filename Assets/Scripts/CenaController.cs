using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaController : MonoBehaviour
{
    [SerializeField] private GameObject creditos;
    [SerializeField] private GameObject pause;
    [SerializeField] private int lvlIndex;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameController gameController;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0 && creditos.activeSelf)
            {
                creditos.SetActive(false);
            }else if(SceneManager.GetActiveScene().buildIndex == 1 && (!gameController.verificarSeTelaGameOverOuTelaVenceuEstaAtivada()))
            {
                if (pause.activeSelf)
                {
                    Time.timeScale = 1;
                    pause.SetActive(false);
                }
                else
                {
                    Time.timeScale = 0;
                    pause.SetActive(true);
                }
            }
        }
    }
    public void sair()
    {
        Application.Quit();
    }

    public void jogar()
    {
        SceneManager.LoadScene(lvlIndex);
    }

    public void voltarTelaInicial()
    {
        SceneManager.LoadScene(lvlIndex);
    }

    public void irCreditos()
    {
        creditos.SetActive(true);
    }
}
