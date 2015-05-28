using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IDamageable {

    int Gethealth();

    void Damage(Dictionary<DamageType, int> damage);

}
