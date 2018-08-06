using Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : PunBehaviour {

    public GameObject playerPrefab;

	void Start () {
        if (playerPrefab == null) {
            Debug.LogError("No player prefab in GameManager");
        }
        else {
            if(PersonController.localPlayerInstance == null)
                PhotonNetwork.Instantiate(this.playerPrefab.name, Vector3.zero, Quaternion.identity, 0);
        }
    }
	
	void Update () {
		
	}

    public override void OnPhotonPlayerConnected(PhotonPlayer other) {
        Debug.Log("PLAYER CONNECTED " + other.NickName);
        if(PhotonNetwork.isMasterClient) {
            LoadArena();
        }
    }

    public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer) {
        Debug.Log("PLAYER |" + otherPlayer.NickName + "|DISCONNECTED");
        if(PhotonNetwork.isMasterClient) {
            LoadArena();
        }
    }

    public override void OnLeftRoom() {
        SceneManager.LoadScene(0);
    }

    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom();
    }

    private void LoadArena() {
        if(!PhotonNetwork.isMasterClient) {
            Debug.LogError("TRYING TO LOAD LEVEL FROM NON MASTERCLIENT");
        }
        Debug.Log("LOADING LEVEL: " + PhotonNetwork.room.PlayerCount);
        PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.room.PlayerCount);

    }


}
