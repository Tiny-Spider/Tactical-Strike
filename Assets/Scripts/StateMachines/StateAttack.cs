﻿using UnityEngine;
using System.Collections;

public class StateAttack : State {
    public override void Enter(Unit unit) {
        Debug.Log("[State] Unit \"" + unit.techName + "\" just entered \"StateAttack\" state!");
    }

    public override void Update(Unit unit) {

    }

    public override void Exit(Unit unit) {

    }
}
