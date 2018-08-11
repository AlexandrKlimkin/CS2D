using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon;

public class MovementController : MonoBehaviour{

    private PhotonView _photonView;
    public PersonController PersonController { get; private set; }
    private Rigidbody2D _rb;


    public float maxSpeed;
    public float speed;

    //public float acceleration;
    public Vector2 Direction;

    private void Awake() {
        PersonController = GetComponent<PersonController>();
        _photonView = GetComponent<PhotonView>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        Direction = Vector2.up;
    }

    private void Update() {
        if (!_photonView.isMine && PhotonNetwork.connected)
            return;
        Move();
    }

    private void Move() {
        if (speed > maxSpeed)
            speed = maxSpeed;
        else if (speed < 0) {
            speed = 0;
        }
        Direction.Normalize();
        var delta = Direction * Time.deltaTime * speed;
        _rb.MovePosition(_rb.position + delta);
    }

    public void SetDirection(Vector2 newDirection) {
        Direction = newDirection;
    }
}