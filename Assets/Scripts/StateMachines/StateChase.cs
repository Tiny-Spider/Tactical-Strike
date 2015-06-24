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
        Debug.Log("[State] Unit \"" + unit.techName + "\" switched to \"StateChase\"");
    }

    public override void Execute(Unit unit) {
        if (unit.target.IsDead()) {
            switch (unit.stance) {
                case Stance.Defensive:
                    unit.SetTargetPosition(unit.startPosition);
                    break;
                default:
                    unit.SwitchToState(StateType.Idle);
                    break;
            }
        }

        if (Vector3.Distance(unit.transform.position, unit.target.GetOwner().transform.position) < unit.attackRange) {
            unit.SwitchToState(StateType.Attack);
        } else {
            unit.navMeshAgent.SetDestination(unit.target.GetOwner().transform.position);
        }
    }

    public override void Exit(Unit unit) {

    }
}
