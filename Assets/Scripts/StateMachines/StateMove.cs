using UnityEngine;
using System.Collections;

public class StateMove : State {
    public override void Enter(Unit unit) {
        Debug.Log("[State] Unit \"" + unit.techName + "\" just entered \"StateMove\" state!");
        Debug.Log(unit.targetPosition);
        unit.navMeshAgent.SetDestination(unit.targetPosition);
    }

    public override void Update(Unit unit) {
        if (!unit.navMeshAgent.pathPending) {
            if (unit.navMeshAgent.remainingDistance <= unit.navMeshAgent.stoppingDistance) {
                if (!unit.navMeshAgent.hasPath || unit.navMeshAgent.velocity.sqrMagnitude == 0f) {
                    unit.SwitchToState(StateType.Idle);
                }
            }
        }
    }

    public override void Exit(Unit unit) {
        unit.navMeshAgent.ResetPath();
        //unit.targetPosition = Vector3.zero;
    }
}
