using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public PersonController player;
    private MovementController _playerMovementController;
    private RotationController _playerRotationController;

    void Start () {
        _playerMovementController = player.MovementController;
        _playerRotationController = player.RotationController;
	}
	
	void Update () {
        MovementControl();
        RotationControl();
	}

    private void MovementControl() {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var direction = new Vector2(horizontal, vertical);
        _playerMovementController.SetDirection(direction);
    }

    private void RotationControl() {
        var mouseScreenPos = Input.mousePosition;
        var mousePos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        var sight = mousePos - player.transform.position;
        var orientation = Vector2.Angle(sight, Vector2.up);
        if (mousePos.x > player.transform.position.x)
            orientation = 360 - orientation;        
        _playerRotationController.SetOrientation(orientation);
    }
}