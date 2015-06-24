using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : RTSObject {
    public List<UnitState> states;

    public float baseDamage, baseMovementSpeed, baseAttackRange;

    private State state;

    public Vector3 targetPosition;
    public IDamageable target;

    public NavMeshAgent navMeshAgent;
    public Stance stance = Stance.Hold;
    public LayerMask attackableLayer;

    public float attackRange;


    void Awake() {
        Dictionary<StateType, State> stateDictionary = new Dictionary<StateType,State>();

        foreach(UnitState state in states) {
            stateDictionary.Add(state.stateType, state.state);
        }

        RTSObject.states.Add(techName, stateDictionary);

        SwitchToState(StateType.Idle);
    }

    void Update() {
        if (state != null) {
            state.Update(this);
        }
    }

    public void SetTargetPosition(Vector3 targetPosition) {
        this.targetPosition = targetPosition;

        SwitchToState(StateType.Move);
    }

    public void SetTarget(IDamageable target) {
        this.target = target;

        SwitchToState(StateType.Attack);
    }

    public void SwitchToState(StateType stateType) {
        // For the first time
        if (state != null)
            state.Exit(this);

        state = RTSObject.states[techName][stateType];
        state.Enter(this);
    }

}

[System.Serializable]
public struct UnitState {
    public StateType stateType;
    public State state;
}
