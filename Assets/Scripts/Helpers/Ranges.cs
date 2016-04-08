using UnityEngine;
using System.Collections;

public class Ranges : Object {

	public static bool InRange(Transform trans1, Transform trans2, float distance)
	{
		var x1 = trans1.position.x;
		var y1 = trans1.position.y;

		var x2 = trans2.position.x;
		var y2 = trans2.position.y;

		return Mathf.Abs(x1 - x2) < distance && Mathf.Abs(y1 - y2) < distance;
	}
}
