using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InputManager : Singleton<InputManager> {
    public enum State {
        pressed,
        released
    }

    private Dictionary<Tuple<KeyCode, State>, Action> actions;

    public InputManager() {
        actions = new Dictionary<Tuple<KeyCode, State>, Action>();
    }

    public void Awake() {
        DontDestroyOnLoad(this);
    }

    public void BindAction(KeyCode action, State state, Action callBack) {
        Tuple<KeyCode, State> actionPair = Tuple.Create(action, state);
        if (actions.ContainsKey(actionPair)) {
            actions[actionPair] += callBack;
        } else {
            actions.Add(actionPair, callBack);
        }
    }

    public void RemoveActionBinding(KeyCode action, State state, Action callBack) {
        Tuple<KeyCode, State> actionPair = Tuple.Create(action, state);
        if (actions.ContainsKey(actionPair)) {
            actions[actionPair] -= callBack;
        }
    }

    public void RemoveAllActionBindings() {
        actions.Clear();
    }

    public void RemoveAllBindingsFromAction(KeyCode action, State state) {
        actions.Remove(Tuple.Create(action, state));
    }

    public void RemoveAllBindings() {
        actions.Clear();
    }

    public void Execute() {
        foreach (KeyValuePair<Tuple<KeyCode, State>, Action> entry in actions) {
            switch (entry.Key.Item2) {
                case State.pressed: {
                        if (Input.GetKeyDown(entry.Key.Item1))
                            entry.Value();
                    }
                    break;
                case State.released: {
                        if (Input.GetKeyUp(entry.Key.Item1))
                            entry.Value();
                    }
                    break;
            }
        }
    }
}
