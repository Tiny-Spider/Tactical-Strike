using UnityEngine;
using System.Collections;

public abstract class State {
    public abstract void Enter(Unit unit);

    public abstract void Update(Unit unit);

    public abstract void Exit(Unit unit);
}
