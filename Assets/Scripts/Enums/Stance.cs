using UnityEngine;
using System.Collections;

public enum Stance {
    Hold, //Stands still at current position.
    Guard, //Holds the area within the radius. If an enemy enters the radius the unit chases it until its out of range and then he moves back to the guard position.
<<<<<<< HEAD
    Aggressive, //Attacks enemies when they come in its attack range. He will chase untill sight of the enemy is lost or when he is out of chasing range.
=======
    Aggressive, //Attack an unit that entered the unit attack radius. Keep following it until it's dead. Stand still on the position of kill.
	Defensive, //Stand still at the current position. If an enemy enters the attack radius start attacking it. DO NOT FOLLOW IT.
>>>>>>> f7ee493b572fd84fd8ef435c41c70612f19b12cc
}
