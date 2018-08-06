using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : Weapon {

    public Projectile projectilePrefab;
    public int pelletCount;
    public float pelletsAngle;

    public override void Awake() {
        base.Awake();
        projectilePrefab = Resources.Load<GunProjectile>("Prefabs/Projectiles/PistolProjectile");
    }

    protected override void Shot() {
        var startAngle = -pelletsAngle / 2;
        var addAngle = pelletsAngle / pelletCount;
        for (int i = 0; i < pelletCount; i++) {
            var angle = startAngle + addAngle * i;

            var projectile = ShotgunProjectilePool.Instance.GetObject();
            projectile.gameObject.SetActive(true);
            projectile.transform.position = FirePoint.position;
            projectile.transform.rotation = FirePoint.rotation;
            projectile.transform.Rotate(new Vector3(0, 0, angle));
            projectile.SetVelocity();
        }
    }
}
