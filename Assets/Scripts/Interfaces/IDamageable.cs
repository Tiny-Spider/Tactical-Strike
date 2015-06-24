using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IDamageable {

    int Gethealth();
    int SetHealth(int amount);
    int Heal(int amount);

    bool IsDead();

    void Damage(Dictionary<DamageType, int> damage);
    void Die();

    RTSObject GetOwner();
}
