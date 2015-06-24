using UnityEngine;
using System.Collections;

public class StateFlee : State<Unit> {
    private static readonly StateFlee _instance = new StateFlee();
    public static StateFlee instance {
        get {
            return _instance;
        }
    }

    public override void Enter(Unit unit) {
        Debug.Log("[State] Unit \"" + unit.techName + "\" switched to \"StateFlee\"");
    }

    public override void Execute(Unit unit) {

    }

    public override void Exit(Unit unit) {

    }
}
