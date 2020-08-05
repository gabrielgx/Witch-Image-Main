using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{

    public static PhotonRoom room;
    private PhotonView PV;

    public bool isGameLoaded;
    public int currentScene;
    public int multplayScene;

    Player[] photonPlayers;
    public int PlayersInRoom;
    public int myNumberInRoom;
    public int playersInGame;


    private void Awake()
    {
        if(PhotonRoom.room == null)
        {
            PhotonRoom.room = this;
        }else if(PhotonRoom.room != this)
        {
            Destroy(PhotonRoom.room.gameObject);
            PhotonRoom.room = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Conectado a uma sala");
        if (!PhotonNetwork.IsMasterClient)
            return;
            StartGame();
        
    }


    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        Debug.Log("Carregando a fase");
        PhotonNetwork.LoadLevel(multplayScene);
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.buildIndex;
        
        if(currentScene == multplayScene)
        {
            {
                CreatePlayer();
            }
        }
    }

    private void CreatePlayer()
    {
        Debug.Log("Criando jogador");
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "PhotonNetworkPlayer"), transform.position, Quaternion.identity, 0);
    }

}