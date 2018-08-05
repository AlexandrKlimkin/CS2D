using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public PersonController PersonController { get; private set; }

    public float maxSpeed;
    public float Speed;
    public float acceleration;
    [SerializeField] private Vector2 _direction;

    private void Awake() {
        PersonController = GetComponent<PersonController>();
    }

    private void Start() {
        _direction = Vector2.up;
    }

    private void Update() {
        Move();
    }

    private void Move() {
        if (Speed > maxSpeed)
            Speed = maxSpeed;
        else if (Speed < 0) {
            Speed = 0;
        }
        _direction.Normalize();
        var delta = _direction * Time.deltaTime * Speed;
        transform.Translate(delta, Space.World);
    }

    public void SetDirection(Vector2 newDirection) {
        _direction = newDirection;
    }    
}