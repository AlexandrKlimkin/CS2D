using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Damage {
    public float amount;
    public PersonController instigator;

    public Damage(float amount, PersonController instigator = null) {
        this.amount = amount;
        this.instigator = instigator;
    }
}