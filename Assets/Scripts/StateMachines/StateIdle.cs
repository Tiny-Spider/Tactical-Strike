using UnityEngine;
using System.Collections;

public class StateIdle : State {
    public override void Enter(Unit unit) {
        
    }

    public override void Update(Unit unit) {

        switch (unit.stance) {
            case Stance.Aggressive: {
                    Collider[] colliders = Physics.OverlapSphere(unit.transform.position, unit.attackRange, unit.attackableLayer);

                    foreach (Collider collider in colliders) {
                        IDamageable iDamageable = collider.GetComponent<IDamageable>();
                        RTSObject rtsObject = iDamageable.GetOwner();

                        if (rtsObject.team != unit.team) {
                            unit.SetTarget(iDamageable);
                            break;
                        }
                    }
                }
                break;
            case Stance.Defensive: {
                    Collider[] colliders = Physics.OverlapSphere(unit.transform.position, unit.attackRange, unit.attackableLayer);

                    foreach (Collider collider in colliders) {
                        IDamageable iDamageable = collider.GetComponent<IDamageable>();
                        RTSObject rtsObject = iDamageable.GetOwner();

                        if (rtsObject.team != unit.team) {
                            unit.SetTarget(iDamageable);
                            break;
                        }
                    }
                }
                break;
            case Stance.Guard: {
                    Collider[] colliders = Physics.OverlapSphere(unit.transform.position, unit.attackRange, unit.attackableLayer);

                    foreach (Collider collider in colliders) {
                        IDamageable iDamageable = collider.GetComponent<IDamageable>();
                        RTSObject rtsObject = iDamageable.GetOwner();

                        if (rtsObject.team != unit.team) {
                            unit.SetTarget(iDamageable);
                            break;
                        }
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
