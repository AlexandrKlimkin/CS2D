using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour {

    public PersonController PersonController { get; private set; }

    public float orientation;
    public float rotationSpeed;

    private void Awake() {
        PersonController = GetComponent<PersonController>();
    }

    void Start () {
		
	}

	void Update () {
        Rotate();
	}

    private void Rotate() {
        if (orientation > 360)
            orientation -= 360;
        else if (orientation < 0) {
            orientation += 360;
        }
        transform.rotation = new Quaternion();
        transform.Rotate(Vector3.forward, orientation);
    }

    public void SetOrientation(float newOrientation) {
        orientation = newOrientation;
    }
}
