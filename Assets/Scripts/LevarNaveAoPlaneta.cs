using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevarNaveAoPlaneta : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject planeta;
    [SerializeField] private SeguirJogador seguirJogador;
    [SerializeField] private float velocidadeParaLevarNaveAtePlaneta;
    [SerializeField] private float distanciaMaxPlaneta;

    private void Start()
    {
        this.enabled = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direcaoPlaneta = planeta.transform.position - player.transform.position;

        if (direcaoPlaneta.magnitude < distanciaMaxPlaneta)
        {
            this.enabled = false;
            player.setVitoria(true);
            return;
        }
        else
        {
            direcaoPlaneta.Normalize();
            player.addForce(direcaoPlaneta, velocidadeParaLevarNaveAtePlaneta);
        }

    }

    public void levarPlayerAoPlaneta()
    {
        this.enabled = true;
        seguirJogador.enabled = false;
        
    }
}
