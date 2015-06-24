using UnityEngine;
using System.Collections;

public class StateMove : State {
    public override void Enter(Unit unit) {
        unit.navMeshAgent.SetDestination(unit.targetPosition);
    }

    public override void Update(Unit unit) {
        
    }

    public override void Exit(Unit unit) {

    }
}
