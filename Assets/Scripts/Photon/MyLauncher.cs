using Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLauncher : PunBehaviour {

    public GameObject controlPanel;
    public GameObject progressLabel;

    public PhotonLogLevel LogLevel = PhotonLogLevel.Informational;
    public byte maxPlayersPerRoom = 4;

    private string _gameVersion = "1";
    private bool _isConnecting;

    private void Awake() {
        PhotonNetwork.autoJoinLobby = false; //// we don't join the lobby. There is no need to join a lobby to get the list of rooms.
        PhotonNetwork.automaticallySyncScene = true; //this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
    }

    private void Start() {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
        PhotonNetwork.logLevel = LogLevel;
        //Connect();
    }

    public void Connect() {
        _isConnecting = true;
        progressLabel.SetActive(true);
        controlPanel.SetActive(false);
        if (PhotonNetwork.connected)
            PhotonNetwork.JoinRandomRoom();
        else
            PhotonNetwork.ConnectUsingSettings(_gameVersion);
    }

    public override void OnConnectedToMaster() {
        Debug.Log("CONNECTED TO MASTER");
        if(_isConnecting)
            PhotonNetwork.JoinRandomRoom();
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg) {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = maxPlayersPerRoom }, null);
        Debug.Log("RANDOM JOIN FAILED");
    }

    public override void OnJoinedRoom() {
        if(PhotonNetwork.room.PlayerCount == 1) {
            Debug.Log("LOADING ROOM FOR 1...");
            PhotonNetwork.LoadLevel("Room for 1");
        }
        Debug.Log("ROOM JOINED");
    }

    public override void OnDisconnectedFromPhoton() {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
        base.OnDisconnectedFromPhoton();
    }

}
