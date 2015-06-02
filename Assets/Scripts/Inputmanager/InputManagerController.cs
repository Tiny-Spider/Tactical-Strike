using UnityEngine;
using System.Collections;
using InControl;
using System.Collections.Generic;
using System;

public class InputManagerController : MonoBehaviour
{
	public enum State
	{
		pressed,
		released
	}

	private Dictionary<Tuple<InputControlType, State>, Action> actions;
	private Dictionary<InputControlType, Action<float>> axis;

	private InputDevice device;

	public InputManagerController()
	{
		actions = new Dictionary<Tuple<InputControlType, State>, Action>();
		axis = new Dictionary<InputControlType, Action<float>>();
	}

	public void Awake()
	{
		//if (this != Game.Instance().GetInputManager())
		//	Destroy(this.gameObject);
		DontDestroyOnLoad(this);
		device = InputManager.ActiveDevice;
	}

	public void BindAction(InputControlType action, State state, Action callBack)
	{
		Tuple<InputControlType, State> actionPair = Tuple.Create(action, state);
		if (actions.ContainsKey(actionPair))
		{
			actions[actionPair] += callBack;
		}
		else
		{
			actions.Add(actionPair, callBack);
		}
	}

	public void RemoveActionBinding(InputControlType action, State state, Action callBack)
	{
		Tuple<InputControlType, State> actionPair = Tuple.Create(action, state);
		if (actions.ContainsKey(actionPair))
		{
			actions[actionPair] -= callBack;
		}
	}

	public void RemoveAllActionBindings()
	{
		actions.Clear();
	}

	public void RemoveAllBindingsFromAction(InputControlType action, State state)
	{
		actions.Remove(Tuple.Create(action, state));
	}

	public void BindAxis(InputControlType axis, Action<float> callBack)
	{
		if (this.axis.ContainsKey(axis))
		{
			this.axis[axis] += callBack;
		}
		else
		{
			this.axis.Add(axis, callBack);
		}
	}

	public void RemoveAxisBinding(InputControlType axis, Action<float> callBack)
	{
		if (this.axis.ContainsKey(axis))
		{
			this.axis[axis] -= callBack;
		}
	}

	public void RemoveAllAxisBindings()
	{
		axis.Clear();
	}

	public void RemoveAllBindingsFromAxis(InputControlType axis)
	{
		this.axis.Remove(axis);
	}

	public void RemoveAllBindings()
	{
		axis.Clear();
		actions.Clear();
	}

	public void Execute()
	{
		foreach (KeyValuePair<InputControlType, Action<float>> entry in axis)
		{
			InputControl control = device.GetControl(entry.Key);
			entry.Value(control.Value);
		}

		foreach (KeyValuePair<Tuple<InputControlType, State>, Action> entry in actions)
		{
			InputControl control = device.GetControl(entry.Key.Item1);
			if (control.HasChanged)
			{
				switch (entry.Key.Item2)
				{
					case State.pressed:
					{
						if (control.IsPressed)
							entry.Value();
					} break;
					case State.released:
					{
						if (!control.IsPressed)
							entry.Value();
					} break;
				}
			}
		}
	}
}
