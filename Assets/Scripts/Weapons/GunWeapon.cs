using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : Weapon {

    public Projectile projectilePrefab;

    public override void Awake() {
        base.Awake();
        projectilePrefab = Resources.Load<GunProjectile>("Projectiles/PistolProjectile");
    }    

    protected override void Shot() {
        Instantiate(projectilePrefab, FirePoint.position, FirePoint.rotation);
    }
}
