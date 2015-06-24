using UnityEngine;
using System.Collections;

public class StateAttack : State<Unit> {
    private static readonly StateAttack _instance = new StateAttack();
    public static StateAttack instance {
        get {
            return _instance;
        }
    }

    public override void Enter(Unit unit) {
        Debug.Log("[State] Unit \"" + unit.techName + "\" switched to \"StateAttack\"");
    }

    public override void Execute(Unit unit) {
        if (unit.target == null || !unit.target.GetOwner()) {
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

        Vector3 targetPosition = unit.target.GetOwner().transform.position;

        if (Vector3.Distance(unit.transform.position, targetPosition) > unit.attackRange) {
            switch (unit.stance) {
                case Stance.Guard:
                    unit.SwitchToState(StateType.Idle);
                    break;
                default:
                    unit.SwitchToState(StateType.Chase);
                    break;
            }
        } else {
            if (Time.time > unit.nextAttackTime) {
                unit.nextAttackTime = Time.time + unit.attackSpeed;
                unit.target.Damage(unit.GetDamage());

                if (unit.target.IsDead()) {
                    unit.SetTargetPosition(unit.startPosition);
                }
            }
        }
    }

    public override void Exit(Unit unit) {

    }
}
