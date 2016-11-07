using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float damage;

	public float cooldown;
	private float cooldownCounter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!IsCool())
			cooldownCounter -= Time.deltaTime;
		
	}

	public bool IsCool()
	{
		return cooldownCounter <= 0;
	}


	public void Warm()
	{
		cooldownCounter = cooldown;
	}
}
