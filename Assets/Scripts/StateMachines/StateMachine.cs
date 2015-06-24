using UnityEngine;
using System.Collections;

public class StateMachine<T> {
    private T owner;
    private State<T> currentState;
    private State<T> previousState;
    private State<T> globalState;

    public void Awake() {
        currentState = null;
        previousState = null;
        globalState = null;
    }

    public StateMachine(T owner, State<T> InitialState) {
        this.owner = owner;
        ChangeState(InitialState);
    }

    public void Update() {
        if (globalState != null) { 
            globalState.Execute(owner); 
        }

        if (currentState != null) {
            currentState.Execute(owner);
        }
    }

    public void ChangeState(State<T> NewState) {
        previousState = currentState;
        if (currentState != null) {
            currentState.Exit(owner);
        }
        
        currentState = NewState;
        if (currentState != null) {
            currentState.Enter(owner);
        }
    }

    public void RevertToPreviousState() {
        if (previousState != null) {
            ChangeState(previousState);
        }
    }
};
