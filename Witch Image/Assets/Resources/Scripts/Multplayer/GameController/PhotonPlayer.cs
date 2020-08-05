using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{

    public PhotonView PV;
    public GameObject myAvatar;
    public int myTeam;
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine){
            PV.RPC("RPC_GetTeam", RpcTarget.MasterClient);        
        
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myAvatar == null && myTeam != 0)
        {


            if (myTeam == 1)
            {
                int spawnPicker = Random.Range(0, GameSetupController.GS.spawnPointsTeam1.Length);
                if (PV.IsMine)
                {
                    myAvatar = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "PlayerAvatar"),
                        GameSetupController.GS.spawnPointsTeam1[spawnPicker].position, GameSetupController.GS.spawnPointsTeam1[spawnPicker].rotation, 0);
                }
            }
            else
            {
                int spawnPicker = Random.Range(0, GameSetupController.GS.spawnPointsTeam2.Length);
                if (PV.IsMine)
                {
                    myAvatar = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "PlayerAvatar"),
                        GameSetupController.GS.spawnPointsTeam2[spawnPicker].position, GameSetupController.GS.spawnPointsTeam2[spawnPicker].rotation, 0);
                }
            }
        }
    }
    [PunRPC]

    void RPC_GetTeam()
    {
        myTeam = GameSetupController.GS.nextPlayersTeam;
        GameSetupController.GS.UpdateTeam();
        PV.RPC("RPC_SentTeam", RpcTarget.OthersBuffered, myTeam);
    }

    [PunRPC]
    void RPC_SentTeam(int whichTeam)
    {
        myTeam = whichTeam;
    }
}
