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
    }

    public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer) {
        Debug.Log("PLAYER |" + otherPlayer.NickName + "|DISCONNECTED");
    }

    public override void OnLeftRoom() {
        SceneManager.LoadScene(0);
    }

    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom();
    }
}
