using UnityEngine;
using System.Collections;

public enum Stance {
    Hold, //Stands still at current position.
    Guard, //Holds the area within the radius. If an enemy enters the radius the unit chases it until its out of range and then he moves back to the guard position.
    Aggressive,
}
