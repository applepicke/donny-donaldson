using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CompanyIntroManager : MonoBehaviour {

	public float timeout = 16f;

	// Use this for initialization
	void Start () {
		if (!Application.isEditor)
			Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {

		var start = Input.GetButtonDown("Start");
		var submit = Input.GetButtonDown("Jump");

		if (timeout < 0 || start || submit)
		{
			SceneManager.LoadScene("Playground");
			return;
		}

		timeout -= Time.deltaTime;

	}
}
