using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using InControl;

public class PlayerActions : PlayerActionSet
{
	public PlayerAction repair;
	public PlayerAction build;
	public PlayerAction pause;
	public PlayerAction left;
	public PlayerAction right;
	public PlayerAction up;
	public PlayerAction down;
	public PlayerTwoAxisAction CameraMove;

	public PlayerActions()
	{
		repair = CreatePlayerAction("Repair");
		build = CreatePlayerAction("Build");
		pause = CreatePlayerAction("Pause");
		left = CreatePlayerAction("Move camera left");
		right = CreatePlayerAction("Move camera right");
		up = CreatePlayerAction("Move camera up");
		down = CreatePlayerAction("Move camera down");
		CameraMove = CreateTwoAxisPlayerAction(left, right, up, down);
	}
}
public class KeyInputManager : MonoBehaviour
{
	//TODO: Request the right camera
	PlayerActions playerInput;
	public GameObject UIButtonPrefab;
	public RectTransform UIInputPanel;
	public RectTransform UIActionParent;
	string saveData;

	void OnEnable()
	{
		playerInput = new PlayerActions();
		//Test hotkeys
		playerInput.repair.AddDefaultBinding(Key.R);
		playerInput.build.AddDefaultBinding(Key.B);
		playerInput.pause.AddDefaultBinding(Key.Escape);
		
		//Camera control
		playerInput.left.AddDefaultBinding(Key.LeftArrow);
		playerInput.right.AddDefaultBinding(Key.RightArrow);
		playerInput.up.AddDefaultBinding(Key.UpArrow);
		playerInput.down.AddDefaultBinding(Key.DownArrow);

		playerInput.ListenOptions.MaxAllowedBindings = 1;

		LoadBindings();

		playerInput.ListenOptions.OnBindingAdded += (action, binding) =>
		{
			Debug.Log("Binding added... " + binding.DeviceName + ": " + binding.Name);
		};

		playerInput.ListenOptions.OnBindingRejected += (action, binding, reason) =>
		{
			Debug.Log("Binding rejected... " + reason);
		};

		//if (playerInput.listenWithAction.IsPressed)
		//	Debug.Log(playerInput.LastInputType.ToString());
	}
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Vector3 movePosition = Camera.main.transform.position;
		if (playerInput.CameraMove.IsPressed)
			MoveMainCamera(movePosition);

		if(playerInput.repair.IsPressed)
		{
			Debug.Log(playerInput.LastInputType);
		}

		if(playerInput.pause.WasPressed)
		{
			UseUIButtonInformation();
		}
	}

	void UseUIButtonInformation()
	{
		//TODO: Gain information from button about what action it controls and what it should do when clicked
		//		Possible by making a prefab UI button that will be loaded just like in CubeController, Name, KeyType & Reset button
		var actionCount = playerInput.Actions.Count;
		for (int i = 0; i < actionCount; i++)
		{
			var action = playerInput.Actions[i];
			var name = action.Name;

			Button tempParent = GameObject.Instantiate(UIActionParent).GetComponent<Button>();
			tempParent.name = name + " parent";
			tempParent.transform.SetParent(UIInputPanel.transform, false);

			//Spawn a 'button' with the action name as text
			Button tempButtonName = GameObject.Instantiate(UIButtonPrefab).GetComponent<Button>();
			tempButtonName.name = name;
			tempButtonName.GetComponentInChildren<Text>().text = name;
			tempButtonName.transform.SetParent(tempParent.transform, false);

			//Spawn a button with the binding name as text
			Button tempButtonKey = GameObject.Instantiate(UIButtonPrefab).GetComponent<Button>();
			tempButtonKey.name = name;
			tempButtonKey.transform.SetParent(tempParent.transform, false);

			var bindingCount = action.Bindings.Count;
			for (int j = 0; j < bindingCount; j++)
			{
				var binding = action.Bindings[j];
				tempButtonKey.GetComponentInChildren<Text>().text = binding.Name;
			}

			//Spawn a button with the keybinding for the action as the name

		}
	}

	void MoveMainCamera(Vector3 movePosition)
	{
		movePosition.x += 5 * Time.deltaTime * playerInput.CameraMove.X;
		movePosition.z -= 5 * Time.deltaTime * playerInput.CameraMove.Y;
		Camera.main.transform.position = movePosition;
	}

	void SaveBindings()
	{
		saveData = playerInput.Save();
		PlayerPrefs.SetString("Bindings", saveData);
	}

	void LoadBindings()
	{
		if(PlayerPrefs.HasKey("Bindings"))
		{
			saveData = PlayerPrefs.GetString("Bindings");
			playerInput.Load(saveData);
		}
	}

	void OnApplicationQuit()
	{
		PlayerPrefs.Save();
	}
}
