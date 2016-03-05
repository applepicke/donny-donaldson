using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	public float verticalOffset = 0f;
	private new Camera camera;

	void Start()
	{
		camera = gameObject.GetComponent<Camera>();
		target = GameObject.Find("donny_teen").GetComponent<Transform>().Find("cameraFollow");
	}

	// Update is called once per frame
	void Update()
	{

		if (target)
		{
			Vector3 pos = new Vector3(target.position.x, target.position.y + verticalOffset, target.position.z);
			Vector3 point = camera.WorldToViewportPoint(pos);
			Vector3 delta = pos - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;

			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}

	}

	public void LookUp()
	{
		verticalOffset = 2f;
	}

	public void LookNormal()
	{
		verticalOffset = 0f;
	}

	public void LookDown()
	{
		verticalOffset = -2f;
	}
}