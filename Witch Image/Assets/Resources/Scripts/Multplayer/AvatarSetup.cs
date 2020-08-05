using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AvatarSetup : MonoBehaviour
{
    private PhotonView PV;
    public GameObject myCharacter;
    public Animator anim;
    public int characterValue;
    public int playerHealth;
    public int playerDamage;
    public Camera myCamera;
    public AudioListener myAl;
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            AddCharacter(0);
        }
        else
        {
            Destroy(myCamera);
            Destroy(myAl);
        }
    }
    
    void AddCharacter(int wichCharacter)
    {
        characterValue = wichCharacter;
        myCharacter = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Arissa 2"), transform.position,transform.rotation);
        myCharacter.transform.parent = transform;
        anim = myCharacter.GetComponent<Animator>();
    }
}
