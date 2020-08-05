using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetupController : MonoBehaviour
{
    public static GameSetupController GS;

    public int nextPlayersTeam;
    public Transform[] spawnPointsTeam1;
    public Transform[] spawnPointsTeam2;

    private void OnEnable()
    {
        if(GameSetupController.GS == null)
        {
            GameSetupController.GS = this;
        }
    }
    
    /*
    public void DisconnectPlayer()
    {
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.IsConnected)
            yield return null;
        SceneManager.LoadScene(Sample.)
    }
    */
    
    public void UpdateTeam()
    {
        if(nextPlayersTeam == 1)
        {
            nextPlayersTeam = 2;
        }
        else
        {
            nextPlayersTeam = 1;
        }

    }
}
