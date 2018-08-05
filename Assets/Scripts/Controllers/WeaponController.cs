using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public PersonController Owner { get; private set; }
    public List<Weapon> Weapons { get; private set; }

    private void Awake() {
        Owner = GetComponentInParent<PersonController>();
        Weapons = new List<Weapon>();
    }

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void AddWeapon(Weapon newWeapon) {
        Weapons.Add(newWeapon);
    }

    public bool Fire() {
        var fired = false;
        foreach(var weapon in Weapons) {
            if (weapon.Fire())
                fired = true;
        }
        return fired;
    }
}
