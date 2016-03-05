using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public MenuManager menuManager
	{
		get { return gameObject.GetComponentInChildren<MenuManager>(); }
	}

	// Use this for initialization
	void Start () {
		if (!Application.isEditor)
			Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
