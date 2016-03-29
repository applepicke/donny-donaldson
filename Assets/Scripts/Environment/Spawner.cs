using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	// Spawn frequency
	public float variant;
	public float delay;
	private float delayCounter;

	// Enemies
	public int perWave;
	private Queue<GameObject> enemies; 

	// Prefabs
	public GameObject enemyType;

	// Use this for initialization
	void Start () {
		enemies = new Queue<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

		delayCounter = delayCounter - Time.deltaTime;

		if (delayCounter <= 0 && enemies.Count < perWave)
		{
			delayCounter = Random.Range(delay - variant, delay + variant);

			var newEnemy = GameObject.Instantiate(enemyType);
			var enemyTransform = newEnemy.GetComponent<Transform>();

			enemyTransform.position = new Vector3(transform.position.x, transform.position.y, 0);

			enemies.Enqueue(newEnemy);
		}

		if (enemies.Count >= perWave && AreAllDead())
			NextWave();
	}

	void NextWave()
	{
		enemies = new Queue<GameObject>();
		delayCounter = delay;
	}

	bool AreAllDead()
	{
		foreach (var enemyObj in enemies)
		{
			var enemy = enemyObj.GetComponent<Enemy>();
			if (!enemy.IsDead())
				return false;
		}

		return true;
	}

	void RemoveDead()
	{

	}
}
