using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respect : MonoBehaviour
{
    public Text texto;
    private GameObject Jogador;
    private Animator anim;
    [Range(0.1f, 200.0f)] public float distancia = 3;

    void Start()
    {
        texto.enabled = false;
        Jogador = GameObject.FindWithTag("Player");
        anim = Jogador.GetComponent<Animator>();
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, Jogador.transform.position) < distancia)
        {
            
            texto.enabled = true;
            if (Input.GetKey(KeyCode.F))
            {
                anim.SetBool("Pray", true);
            }
            
        }
        else
        {
            anim.SetBool("Pray", false);
            texto.enabled = false;
        
        }
    }
}
    


