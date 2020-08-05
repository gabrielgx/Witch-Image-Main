using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobbyCustomMatch : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
    public static PhotonLobbyCustomMatch lobby;
    RoomInfo[] rooms;

    
    public string roomName;
    public int roomSize;
    public GameObject roomListPrefab;
    public Transform roomsPanel;
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
        
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        RemoveRoomListings();
        
        foreach(RoomInfo room in roomList)
        {
            ListRoom(room);
        }
    }

    void RemoveRoomListings()
    {

        while (roomsPanel.childCount != 0)
        {
            Destroy(roomsPanel.GetChild(0).gameObject);
        }
    }

    void ListRoom(RoomInfo room)
    {
        if(room.IsOpen && room.IsVisible){

            GameObject tempListing = Instantiate(roomListPrefab, roomsPanel);
            RoomButton tempButton = tempListing.GetComponent<RoomButton>();
            tempButton.roomName = room.Name;
            tempButton.roomSize = room.MaxPlayers;
            tempButton.setRoom();
        }
    }


   

    public override void OnJoinedRoom()
    {
        Debug.Log("Conectado a uma sala");
    }
    

    public void CreateRoom()
    {
        Debug.Log("Criando uma sala...");
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom(roomName, roomOps); //Cria um nova sala com as configurações que criamos nas linhas acima
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Falha ao criar a sala... tentando novamente");
        
    }
        
    public void OnRoomNameChanged(string nameIn)
    {
        roomName = nameIn;
    }

    public void OnRoomSizeChanged(string sizeIn)
    {
        roomSize = int.Parse(sizeIn);
    }

    public void JoinLobbyClick()
    {
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();

        }


    }
}
