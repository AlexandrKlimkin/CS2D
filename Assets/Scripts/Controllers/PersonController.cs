using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class PersonController : PunBehaviour, IDamagable {

    public static GameObject localPlayerInstance;

    public static List<PersonController> Persons { get; private set; }

    public MovementController MovementController { get; private set; }
    public RotationController RotationController { get; private set; }
    public WeaponController WeaponController { get; private set; }

    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _currentHealth;

    public float CurrentHealth { get { return _currentHealth; }
    }
    public float MaxHealth { get { return _maxHealth; } }

    private void Awake() {
        MovementController = GetComponent<MovementController>();
        RotationController = GetComponent<RotationController>();
        WeaponController = GetComponentInChildren<WeaponController>();
        if (photonView.isMine) {
            localPlayerInstance = gameObject;
        }
    }

    private void Start () {
        _currentHealth = MaxHealth;
    }
	
	private void Update () {
		
	}

    public void ApplyDamage(Damage damage) {
        _currentHealth -= damage.amount;
        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        if(_currentHealth <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
    }
}
