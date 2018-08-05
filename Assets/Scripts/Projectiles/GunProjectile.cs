using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunProjectile : Projectile {

    protected Vector3 _velocity;

    protected override void Start() {
        base.Start();
        _velocity = transform.up * speed;
    }

    public override void SimulateStep(float stepTime) {
        transform.position += _velocity * stepTime;
    }
}