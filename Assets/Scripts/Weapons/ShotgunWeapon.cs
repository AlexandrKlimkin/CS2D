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
        var pos = FirePoint.position;
        var rotZ = FirePoint.rotation.eulerAngles.z;
        PhotonView.RPC("PerformShot", PhotonTargets.All, pos, rotZ);
    }

    [PunRPC]
    private void PerformShot(Vector3 position, float zRotation) {
        var startAngle = -pelletsAngle / 2;
        var addAngle = pelletsAngle / pelletCount;
        for (int i = 0; i < pelletCount; i++) {
            var angle = startAngle + addAngle * i;
            var projectile = ShotgunProjectilePool.Instance.GetObject();
            projectile.gameObject.SetActive(true);
            projectile.transform.position = position;
            projectile.transform.rotation = Quaternion.Euler(0, 0, zRotation);
            projectile.transform.Rotate(new Vector3(0, 0, angle));
            projectile.SetVelocity();
            projectile.Damage = new Damage(damage, Controller.Owner);
        }
    }
}
