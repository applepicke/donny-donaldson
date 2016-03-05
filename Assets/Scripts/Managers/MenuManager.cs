using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Timers;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
	public Canvas menuCanvas;

	public bool paused = false;

	private EventSystem eventSystem;

	private Timer timer = new Timer(1000);
	private bool canPause = true;

	// Use this for initialization
	void Start()
	{
		menuCanvas = gameObject.GetComponentInChildren<Canvas>();
		eventSystem = gameObject.GetComponentInChildren<EventSystem>();
		UnPauseGame();
	}

	// Update is called once per frame
	void Update()
	{
		var startDown = Input.GetButtonDown("Start");
		var startUp = Input.GetButtonUp("Start");


		if (startDown)
			if (paused)
				UnPauseGame();
			else
				PauseGame();

		if (startUp)
			canPause = true;
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
		canPause = false;
		paused = true;
		menuCanvas.enabled = true;
		eventSystem.enabled = true;
	}

	public void UnPauseGame()
	{
		canPause = false;
		paused = false;
		menuCanvas.enabled = false;
		eventSystem.enabled = false;
		Time.timeScale = 1;
	}

	public void QuitGame()
	{
		if (paused)
			Application.Quit();
	}
}
