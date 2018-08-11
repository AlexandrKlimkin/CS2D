using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

    public Damage Damage { get; set; }

    public float speed = 10f;
    public float lifeTime = 2f;
    protected float _birthTime;
    protected float _deathTime;

    protected virtual void OnEnable() {
        _birthTime = Time.time;
        _deathTime = _birthTime + lifeTime;
    }

    protected virtual void Start () {
		
	}
	
	protected virtual void Update () {
        if (Time.time > _deathTime) {
            KillProjectile();
            return;
        }
        SimulateStep(Time.deltaTime);
	}

    public abstract void SimulateStep(float stepTime);

    public virtual void KillProjectile() {
        gameObject.SetActive(false);
    }
}