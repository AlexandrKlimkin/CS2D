using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : Weapon {

    public Projectile projectilePrefab;

    public override void Awake() {
        base.Awake();
        projectilePrefab = Resources.Load<GunProjectile>("Prefabs/Projectiles/PistolProjectile");
    }    

    protected override void Shot() {
        var projectile = PistolProjectilePool.Instance.GetObject();
        projectile.gameObject.SetActive(true);
        projectile.transform.position = FirePoint.position;
        projectile.transform.rotation = FirePoint.rotation;
        projectile.SetVelocity();
    }
}