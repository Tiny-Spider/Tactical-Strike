﻿using UnityEngine;
using System.Collections;

public enum Stance {
    Hold, //Stands still at current position.
    Guard, //Holds the area within the radius. If an enemy enters the radius the unit chases it until its out of range and then he moves back to the guard position.
    Aggressive, //Attack an unit that entered the unit attack radius. Keep following it until it's dead. Stand still on the position of kill.
	Defensive, //Stand still at the current position. If an enemy enters the attack radius start attacking it. DO NOT FOLLOW IT.
}
