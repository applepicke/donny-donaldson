using UnityEngine;
using System.Collections;
using InControl;

public class BottomNavigatable : Navigatable {

	protected override InputControl GetStick()
	{
		return InputManager.ActiveDevice.LeftStickUp;
	}

	public override void Transport()
	{
		var pt = player.GetComponent<Transform>();
		pt.position = new Vector2(pt.position.x, pt.position.y + 3);
		ideaManager.HideAll();

		navManager.SetRoom(GetDestination().room);
	}
}
