using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class PlayerControl : PunBehaviour {

    public PersonController player;
    private MovementController _playerMovementController;
    private RotationController _playerRotationController;
    private WeaponController _playerWeaponController;

    void Start () {
        _playerMovementController = player.MovementController;
        _playerRotationController = player.RotationController;
        _playerWeaponController = player.WeaponController;
	}
	
	void Update () {
        if (!photonView.isMine && PhotonNetwork.connected)
            return;
        MovementControl();
        RotationControl();
        WeaponControl();
	}

    private void MovementControl() {
#if UNITY_STANDALONE
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var direction = new Vector2(horizontal, vertical);
        _playerMovementController.SetDirection(direction);
#endif
    }

    private void RotationControl() {
#if UNITY_STANDALONE
        var mouseScreenPos = Input.mousePosition;
        var mousePos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        var sight = mousePos - player.transform.position;
        var orientation = Vector2.Angle(sight, Vector2.up);
        if (mousePos.x > player.transform.position.x)
            orientation = 360 - orientation;        
        _playerRotationController.SetOrientation(orientation);
#endif
    }

    private void WeaponControl() {
#if UNITY_STANDALONE
        if (Input.GetMouseButton(0)) {
            _playerWeaponController.Fire();
        }
#endif
    }
}