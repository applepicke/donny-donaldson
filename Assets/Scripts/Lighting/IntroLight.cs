using UnityEngine;
using System.Collections;

public class IntroLight : MonoBehaviour {

	// Properties
	public string waveFunction = "sin"; // possible values: sin, tri(angle), sqr(square), saw(tooth), inv(verted sawtooth), noise (random)
	public float baseVal = 0f; // start
	public float amplitude = 1f; // amplitude of the wave
	public float phase = 0f; // start point inside on wave cycle
	public float frequency = 0.5f; // cycle frequency per second

	public float timeout = 17f;

	// Keep a copy of the original color
	private Color originalColor;
	private new Light light;

	// Use this for initialization
	void Start () {
		originalColor = transform.GetComponent<Light>().color;
		light = transform.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {

		if (timeout < 0)
		{
			light.color = originalColor * 0f;
			return;
		}
						
		timeout -= Time.deltaTime;
		light.color = originalColor * (EvalWave());
	}

	float EvalWave()
	{
		float x = (Time.time + phase) * frequency;
		float y;

		x = x - Mathf.Floor(x); // normalized value (0..1)

		if (waveFunction == "sin")
		{
			y = Mathf.Sin(x * 2 * Mathf.PI);
		}
		else if (waveFunction == "tri")
		{
			if (x < 0.5)
				y = 4f * x - 1f;
			else
				y = -4f * x + 3f;
		}
		else if (waveFunction == "sqr")
		{
			if (x < 0.5)
				y = 1f;
			else
				y = -1f;
		}
		else if (waveFunction == "saw")
		{
			y = x;
		}
		else if (waveFunction == "inv")
		{
			y = 1f - x;
		}
		else if (waveFunction == "noise")
		{
			y = 1 - (Random.value * 2);
		}
		else {
			y = 1f;
		}

		return (y * amplitude) + baseVal;
	}
}

