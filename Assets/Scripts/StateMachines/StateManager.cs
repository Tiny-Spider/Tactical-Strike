using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateManager {
    private static Dictionary<RealStateType, State> states = new Dictionary<RealStateType, State>();
    private static bool initalized = false;

    private static void Instatiate() {
        states.Add(RealStateType.Idle, new StateIdle());
        states.Add(RealStateType.Move, new StateMove());
        states.Add(RealStateType.Attack, new StateAttack());

        initalized = true;
    }

    public static State GetState(RealStateType stateType) {
        if (!initalized) {
            Instatiate();
        }

        return states[stateType];
    }
}

public enum RealStateType {
    Idle,
    Move,
    Attack
}
