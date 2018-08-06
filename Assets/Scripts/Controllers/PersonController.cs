using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class PersonController : PunBehaviour {

    public static GameObject localPlayerInstance;

    public static List<PersonController> Persons { get; private set; }

    public MovementController MovementController { get; private set; }
    public RotationController RotationController { get; private set; }
    public WeaponController WeaponController { get; private set; }

    private void Awake() {
        MovementController = GetComponent<MovementController>();
        RotationController = GetComponent<RotationController>();
        WeaponController = GetComponentInChildren<WeaponController>();
        if (photonView.isMine) {
            localPlayerInstance = gameObject;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start () {
        //Persons.Add(this);
    }
	
	private void Update () {
		
	}
}
