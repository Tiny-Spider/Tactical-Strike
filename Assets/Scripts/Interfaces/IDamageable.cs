using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IDamageable {

    int Gethealth();
    int SetHealth(int amount);
    int Heal(int amount);

    void Damage(Dictionary<DamageType, int> damage);

    RTSObject GetOwner();
}
