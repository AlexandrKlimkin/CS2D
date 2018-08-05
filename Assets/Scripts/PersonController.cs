using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour {

    public static List<PersonController> Persons { get; private set; }

    public MovementController MovementController { get; private set; }
    public RotationController RotationController { get; private set; }

    private void Awake() {
        MovementController = GetComponent<MovementController>();
        RotationController = GetComponent<RotationController>();
    }

    private void Start () {
        //Persons.Add(this);
    }
	
	private void Update () {
		
	}
}
