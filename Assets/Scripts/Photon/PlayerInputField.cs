using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class PlayerInputField : MonoBehaviour {

    static string playerNamePrefKey = "PlayerName";

	void Start () {
		string defaultName = "";
        var inputField = GetComponent<InputField>();
        if (inputField != null) {
            if (PlayerPrefs.HasKey(playerNamePrefKey)) {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                inputField.text = defaultName;
            }
        }

        PhotonNetwork.playerName = defaultName;
	}
	
	void Update () {
		
	}

    public void SetPlayerName(string value) {
        PhotonNetwork.playerName = value + " ";

        PlayerPrefs.SetString(playerNamePrefKey, value);
    }
}
