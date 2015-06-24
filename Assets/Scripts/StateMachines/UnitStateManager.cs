using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitStateManager {
    private static Dictionary<UnitState, State<Unit>> states = new Dictionary<UnitState, State<Unit>>();
    private static bool initalized = false;

    private static void Instatiate() {
        states.Add(UnitState.Idle,      StateIdle.instance);
        states.Add(UnitState.Move,      StateMove.instance);
        states.Add(UnitState.Chase,     StateChase.instance);
        states.Add(UnitState.Attack,    StateAttack.instance);
        states.Add(UnitState.Flee,      StateFlee.instance);

        initalized = true;
    }

    public static State<Unit> GetState(UnitState stateType) {
        if (!initalized) {
            Instatiate();
        }

        return states[stateType];
    }
}

public enum UnitState {
    Idle,
    Move,
    Chase,
    Attack,
    Flee
}
