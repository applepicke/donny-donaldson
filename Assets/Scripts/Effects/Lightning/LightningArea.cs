using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightningArea : MonoBehaviour {

	public GameObject topLeft;
	public GameObject bottomRight;

	public GameObject branchPrefab;
	public GameObject boltPrefab;
	List<GameObject> branches;

	public float heightMin;
	public float heightMax;
	public float diagonal;

	public float minTime;
	public float maxTime;

	private float time = 0f;

	// Use this for initialization
	void Start () {
		branches = new List<GameObject>();
		ResetTime();
	}
	
	void ResetTime()
	{
		time = Random.Range(minTime, maxTime);
	}

	// Update is called once per frame
	void Update () {

		if (time <= 0)
		{
			CreateBranch();
			ResetTime();
		}
			
		time = time - Time.deltaTime;

		for (int i = branches.Count - 1; i >= 0; i--)
		{
			//pull the branch lightning component
			BranchLightning branchComponent = branches[i].GetComponent<BranchLightning>();

			//If it's faded out already
			if (branchComponent.IsComplete)
			{
				//destroy it
				Destroy(branches[i]);

				//take it out of our list
				branches.RemoveAt(i);

				//move on to the next branch
				continue;
			}

			//draw and update the branch
			branchComponent.UpdateBranch();
			branchComponent.Draw();
		}

	}

	void CreateBranch()
	{
		GameObject branchObj = (GameObject)GameObject.Instantiate(branchPrefab);
		BranchLightning branchComponent = branchObj.GetComponent<BranchLightning>();

		var pos1 = topLeft.transform.position;
		var pos2 = bottomRight.transform.position;

		var x = Random.Range(pos1.x, pos2.x);
		var y = Random.Range(pos2.y, pos2.y);

		var start = new Vector2(x, y + Random.Range(heightMin, heightMax));
		var end = new Vector2(x + Random.Range(-diagonal, diagonal), y);

		branchComponent.Initialize(start, end, boltPrefab);

		branches.Add(branchObj);
	}

}
