using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] //Cria um componente de animação quando o script for adicionado ao objeto,
public class ControlaAnimacao : MonoBehaviour
{

    
    
    private string turnInputAxis = "Horizontal";

    private Animator anim; //Declarando o animator como uma variável

    [Tooltip("Rate per seconds holding down input")]
    public float rotationRate = 360; //Valor para velocidade da rotação do player

    private PhotonView PV;

    

    void Start()
    {
        PV = GetComponent<PhotonView>();
        anim = GetComponent<Animator>(); //Atribuindo o componente a variável na inicialização
    }


    void Update()
    {
        if (PV.IsMine)
        {
            float turnAxis = Input.GetAxis(turnInputAxis);

            ApplyInput(turnAxis);

            float inputX = Input.GetAxis("Horizontal"); //Capturando os imputs do eixo Horizontal e atribuindo para a variável inputX
            float inputY = Input.GetAxis("Vertical"); //Capturando os imputs do eixo Vertical e atribuindo para a variável inputY

            anim.SetFloat("Horizontal", inputX); //Atribui o valor da variável inputX para o parâmetro Horizontal do controle de animação
            anim.SetFloat("Vertical", inputY); //Atribui o valor da variável inputY para o parâmetro Vertical do controle de animação

            //Correndo ou não
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Run", true); //Segurando o shift esquerdo a bool Run do controle de animação recebe true
            }
            else
            {
                anim.SetBool("Run", false); //Soltando o shift esquerdo a bool Run do controle de animação recebe false
            }

        }
    }

    void ApplyInput(float turnInput)
    {
        Turn(turnInput);
    }


    void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }


    
}