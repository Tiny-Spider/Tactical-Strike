using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : RTSObject {
    public static Dictionary<string, Dictionary<StateType, State<Unit>>> states = new Dictionary<string, Dictionary<StateType, State<Unit>>>();
    //public static Dictionary<string, Dictionary<DamageType, int>> damages = new Dictionary<string, Dictionary<DamageType, int>>();

    public UnitStates unitStates;
    public List<UnitDamage> damage;

    private StateMachine<Unit> stateMachine;
    private Dictionary<DamageType, int> _damage = new Dictionary<DamageType, int>();

    //[HideInInspector]
    public Vector3 targetPosition = Vector3.zero;
    //[HideInInspector]
    public Vector3 startPosition = Vector3.zero;
    public IDamageable target;
    
    public NavMeshAgent navMeshAgent;
    public LayerMask attackableLayer;

    public bool debugStates = false;

    public float attackRange;
    public float viewRange;
    public float attackSpeed;
    [HideInInspector]
    public float nextAttackTime;

    void Awake() {
        //if (!Unit.damages.ContainsKey(techName)) {
        //    Dictionary<DamageType, int> damageDictionary = new Dictionary<DamageType, int>();

        //    foreach (UnitDamage unitDamage in damage) {
        //        damageDictionary.Add(unitDamage.damageType, unitDamage.damageAmount);
        //    }

        //    Unit.damages.Add(techName, damageDictionary);
        //}

        foreach (UnitDamage unitDamage in damage) {
            _damage.Add(unitDamage.damageType, unitDamage.damageAmount);
        }

        if (!Unit.states.ContainsKey(techName)) {
            Dictionary<StateType, State<Unit>> stateDictionary = new Dictionary<StateType, State<Unit>>();

            stateDictionary.Add(StateType.Idle,     UnitStateManager.GetState(unitStates.idleState));
            stateDictionary.Add(StateType.Move,     UnitStateManager.GetState(unitStates.moveState));
            stateDictionary.Add(StateType.Chase,    UnitStateManager.GetState(unitStates.chaseState));
            stateDictionary.Add(StateType.Attack,   UnitStateManager.GetState(unitStates.attackState));
            stateDictionary.Add(StateType.Flee,     UnitStateManager.GetState(unitStates.fleeState));

            Unit.states.Add(techName, stateDictionary);
        }

        stateMachine = new StateMachine<Unit>(this, GetState(StateType.Idle));
    }

    private State<Unit> GetState(StateType stateType) {
        return Unit.states[techName][stateType];
    }

    public Dictionary<DamageType, int> GetDamage() {
        return _damage;
        //return Unit.damages[techName];
    }

    void Update() {
        stateMachine.Update();
    }

    public void SetTargetPosition(Vector3 targetPosition) {
        this.targetPosition = targetPosition;

        SwitchToState(StateType.Move);
    }

    public void SetTarget(IDamageable target) {
        this.target = target;

        switch (stance) {
            case Stance.Aggressive:
            case Stance.Defensive:
                SwitchToState(StateType.Chase);
                break;
            case Stance.Guard:
                SwitchToState(StateType.Attack);
                break;
            default:
                break;
        }
    }

    public void SwitchToState(StateType stateType) {
        stateMachine.ChangeState(GetState(stateType));
    }

    //Selected
    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, viewRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

[System.Serializable]
public struct UnitStates {
    public UnitState idleState;
    public UnitState moveState;
    public UnitState chaseState;
    public UnitState attackState;
    public UnitState fleeState;
}

[System.Serializable]
public struct UnitDamage {
    public DamageType damageType;
    public int damageAmount;
}
