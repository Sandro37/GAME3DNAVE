using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rig;

    [Header("Velocidade Máxima que o jogador pode alcançar")]
    [SerializeField] private float veloMax;

    [Header("Força de movimento em X e Z")]
    [SerializeField] private float forcaX;
    [SerializeField] private float forcaZ;
    
    [Header("Script do GameController")]
    [SerializeField] private GameController gameController;
    // Start is called before the first frame update

    [Header("Angulos da nave")]
    [SerializeField] private float anguloAlvo;
    [SerializeField] private float velocidadeDeRotacao;

    private bool venceuJogo = false;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!venceuJogo)
            move();
    }

    private void move()
    {
        if (rig.velocity.z < veloMax)
        {
            rig.AddForce(0, 0, forcaZ * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rig.AddForce(-1 * forcaX * Time.fixedDeltaTime, 0, 0);
            rotacionar(this.anguloAlvo);
        }else if (Input.GetKey(KeyCode.D))
        {
            rig.AddForce(1 * forcaX * Time.fixedDeltaTime, 0, 0);
            rotacionar(-this.anguloAlvo);
        }
        else
        {
            rotacionar(0);
        }

        void rotacionar(float anguloAlvo)
        {
            Quaternion atualRotacao = rig.rotation;
            Quaternion finalRotacao = Quaternion.Euler(0, 0, anguloAlvo);
            Quaternion novaRotacao = Quaternion.Lerp(atualRotacao, finalRotacao, Time.fixedDeltaTime * velocidadeDeRotacao);
            rig.MoveRotation(novaRotacao);
        }
    }
    public void addForce(Vector3 direcaoPlaneta, float velocidade)
    {
        rig.AddForce(direcaoPlaneta * Time.fixedDeltaTime * velocidade);
    }

    public void setVitoria(bool venceuJogo)
    {
        this.venceuJogo = venceuJogo;
        setVelocity(new Vector3(0,0,0));
    }

    public void setVelocity(Vector3 vector)
    {
        rig.velocity = new Vector3(vector.x, vector.y, vector.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("inimigo"))
        {
            gameController.gameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("planeta"))
        {
            gameController.gameWins();
        }
    }

   
}
