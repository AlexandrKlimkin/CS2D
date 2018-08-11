using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable {
    float CurrentHealth { get; }
    float MaxHealth { get; }

    void ApplyDamage(Damage damage);
    void Die();
}
