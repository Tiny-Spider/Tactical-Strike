using UnityEngine;
using System.Collections;

public class UnitStateMachine : MonoBehaviour {
	float chaseDistance, attackDistance;
	AIState state;

	Vector3 lastLocation;
	Transform target, targetEnemy;
	bool targetingEnemy;

	enum AIState
	{
		Hold,
		Agressive,
		Defensive,
		Gaurd
	}
	// Use this for initialization
	void Start () {
		state = AIState.Agressive;
	}
	
	// Update is called once per frame
	void Update () {
		switch(state)
		{
			case AIState.Agressive:
			Chase();
			break;
			case AIState.Defensive:
			Defensive();
			break;
			case AIState.Gaurd:
			Chase();
			break;
			case AIState.Hold:
			Hold();
			break;
		}
	}

	void Attack()
	{
		//Code to make the unit attack
	}

	void Chase() { 
		if(DistanceToTarget() <= attackDistance)
		{
			Attack();
			return;
		}
		else
		{
			//Code to move the unit towards the target
		}
	}
	void Defensive() { 
		if(DistanceToTarget() <= attackDistance)
		{
			Attack();
		}
	}
	void Hold()	{ }

	float DistanceToTarget()
	{
		return Vector3.Distance(target.position, transform.position);
	}

	void OnTriggerEnter(Collider other)
	{

	}

	void OnTriggerStay(Collider other)
	{
		OnTriggerEnter(other);
	}
}
