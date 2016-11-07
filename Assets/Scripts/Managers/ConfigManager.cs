using UnityEngine;
using System.Collections;
using DevConsole;
using UnityEngine.SceneManagement;

public class ConfigManager : MonoBehaviour {

	// Activating environment
	public float activationTime;
	public float dropDownTime;
	public float activationRange;

	// Use this for initialization
	void Start () {
		SetupCommands();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetupCommands()
	{
		Console.AddCommand(new Command<string>("reset", Reset));
	}

	static void Reset(string arg)
	{
		SceneManager.LoadScene("Playground");
	}
}
