using UnityEngine;
using System.Collections;

public class StateMove : State<Unit> {
    private static readonly StateMove _instance = new StateMove();
    public static StateMove instance {
        get {
            return _instance;
        }
    }

    public override void Enter(Unit unit) {
        if (unit.debugStates)
        Debug.Log("[State] Unit \"" + unit.techName + "\" switched to \"StateMove\"");
        unit.navMeshAgent.SetDestination(unit.targetPosition);
    }

    public override void Execute(Unit unit) {
        if (!unit.navMeshAgent.pathPending) {
            if (unit.navMeshAgent.remainingDistance <= unit.navMeshAgent.stoppingDistance) {
                if (!unit.navMeshAgent.hasPath || unit.navMeshAgent.velocity.sqrMagnitude == 0f) {
                    unit.SwitchToState(StateType.Idle);
                    return;
                }
            }
        }

        switch (unit.stance) {
            case Stance.Aggressive:
                Collider[] colliders = Physics.OverlapSphere(unit.transform.position, unit.viewRange - unit.navMeshAgent.radius, unit.attackableLayer);

                foreach (Collider collider in colliders) {
                    IDamageable iDamageable = collider.GetComponent<IDamageable>();
                    RTSObject rtsObject = iDamageable.GetOwner();

                    if (rtsObject.team != unit.team) {
                        unit.SetTarget(iDamageable);
                        break;
                    }
                }
                break;
            default:
                break;
        }
    }

    public override void Exit(Unit unit) {
        unit.navMeshAgent.ResetPath();
    }
}
