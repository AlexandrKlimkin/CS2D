using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public WeaponController Controller { get; private set; }
    public Transform FirePoint { get; private set; }

    public float reloadingTime = 0.5f;
    private float _lastShotTime = 0;


    public virtual void Awake() {
        Controller = GetComponentInParent<WeaponController>();
        FirePoint = transform.GetChild(0);
    }

    protected virtual void Start () {
        Controller.AddWeapon(this);
	}

    public virtual bool Fire() {
        if (Time.time > _lastShotTime + reloadingTime) {
            Shot();
            _lastShotTime = Time.time;
            return true;
        }
        return false;
    }

    protected abstract void Shot(); 
}
