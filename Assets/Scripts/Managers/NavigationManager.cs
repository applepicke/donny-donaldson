using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavigationManager : MonoBehaviour {

	public GameObject currentRoom;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("donny");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool InRoom(GameObject room)
	{
		return room == currentRoom;
	}

	public void SetRoom(GameObject room)
	{
		currentRoom = room;
	}

}
