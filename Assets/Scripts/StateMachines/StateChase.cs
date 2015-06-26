using UnityEngine;
using System.Collections;

public class StateChase : State<Unit> {
    private static readonly StateChase _instance = new StateChase();
    public static StateChase instance {
        get {
            return _instance;
        }
    }

    public override void Enter(Unit unit) {
        if (unit.debugStates)
        Debug.Log("[State] Unit \"" + unit.techName + "\" switched to \"StateChase\"");
    }

    public override void Execute(Unit unit) {
        if (unit.target == null || unit.target.GetOwner() == null || unit.target.GetOwner().transform == null || unit.target.IsDead()) {
            switch (unit.stance) {
                case Stance.Defensive:
                    unit.SetTargetPosition(unit.startPosition);
                    break;
                default:
                    unit.SwitchToState(StateType.Idle);
                    break;
            }

            return;
        }

        Vector3 myPosition = unit.transform.position;
        Vector3 targetPosition = unit.target.GetOwner().transform.position;

        if (Vector3.Distance(myPosition, targetPosition) < unit.attackRange) {
            unit.SwitchToState(StateType.Attack);
        } else {
            unit.navMeshAgent.SetDestination(unit.target.GetOwner().transform.position);
        }
    }

    public override void Exit(Unit unit) {

    }
}
