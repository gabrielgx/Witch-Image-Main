using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    RoomInfo[] rooms;

    public GameObject battleButton;
    public GameObject cancelButton;
    private void Awake()
    {
        lobby = this;
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado no servidor " + PhotonNetwork.CloudRegion);
        PhotonNetwork.AutomaticallySyncScene = true;
        battleButton.SetActive(true);
    }

    public void onBattleButonClicked()
    {
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Conectado a uma sala");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Falha ao conectar em uma sala");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Criando uma sala...");
        int randomRoomNumber = Random.Range(0, 10000); //Cria um nome aleatório para a sala
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 7 };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps); //Cria um nova sala com as configurações que criamos nas linhas acima
        Debug.Log(randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Falha ao criar a sala... tentando novamente");
        CreateRoom(); //Tenta criar a sala novamente com um nome diferente
    }

    public void onCancelButtonClicked()
    {
        battleButton.SetActive(true);
        cancelButton.SetActive(false);
        PhotonNetwork.LeaveRoom();
    }
}
