using UnityEngine;
using System.Collections;

public class StateIdle : State<Unit> {
    private static readonly StateIdle _instance = new StateIdle();
    public static StateIdle instance {
        get {
            return _instance;
        }
    }

    public override void Enter(Unit unit) {
        Debug.Log("[State] Unit \"" + unit.techName + "\" switched to \"StateIdle\"");
    }

    public override void Execute(Unit unit) {

        switch (unit.stance) {
            case Stance.Aggressive:
            case Stance.Defensive:
                Collider[] colliders = Physics.OverlapSphere(unit.transform.position, unit.viewRange - unit.navMeshAgent.radius, unit.attackableLayer);

                foreach (Collider collider in colliders) {
                    IDamageable iDamageable = collider.GetComponent<IDamageable>();
                    RTSObject rtsObject = iDamageable.GetOwner();

                    if (rtsObject.team != unit.team) {
                        unit.SetTarget(iDamageable);
                        unit.startPosition = unit.transform.position;
                    }
                }
                break;
            case Stance.Guard:
                colliders = Physics.OverlapSphere(unit.transform.position, unit.attackRange - unit.navMeshAgent.radius, unit.attackableLayer);

                foreach (Collider collider in colliders) {
                    IDamageable iDamageable = collider.GetComponent<IDamageable>();
                    RTSObject rtsObject = iDamageable.GetOwner();

                    if (rtsObject.team != unit.team) {
                        unit.SetTarget(iDamageable);
                        unit.startPosition = unit.transform.position;
                    }
                }
                break;
            case Stance.Hold:
            default:

                break;
        }
    }

    public override void Exit(Unit unit) {

    }
}
