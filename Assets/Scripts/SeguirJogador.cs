using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJogador : MonoBehaviour
{

    private PlayerController player;

    [Header("Componente que define a distanci quea camera vai ficar do jogador")]
    [SerializeField]private Vector3 distanciaParaJogador;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            this.transform.position = player.transform.position + distanciaParaJogador;
        }
    }
}
