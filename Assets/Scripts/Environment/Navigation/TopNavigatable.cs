using UnityEngine;
using System.Collections;
using InControl;

public class TopNavigatable : Navigatable {

	protected override InputControl GetStick()
	{
		return InputManager.ActiveDevice.LeftStickDown;
	}

	public override void Transport()
	{
		var pt = player.GetComponent<Transform>();
		var dt = destination.GetComponent<Transform>();

		pt.position = new Vector2(dt.position.x, dt.position.y);
		ideaManager.HideAll();

		navManager.SetRoom(GetDestination().room);
	}
}
