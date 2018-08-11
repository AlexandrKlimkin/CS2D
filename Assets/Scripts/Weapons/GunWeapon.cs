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
        var pos = FirePoint.position;
        var rotZ = FirePoint.rotation.eulerAngles.z;
        PhotonView.RPC("PerformShot", PhotonTargets.All, pos, rotZ);
    }

    [PunRPC]
    private void PerformShot(Vector3 position, float zRotation) {
        var projectile = PistolProjectilePool.Instance.GetObject();
        projectile.gameObject.SetActive(true);
        projectile.transform.position = position;
        projectile.transform.rotation = Quaternion.Euler(0, 0, zRotation);
        projectile.SetVelocity();
        projectile.Damage = new Damage(damage, Controller.Owner);
    }
}