using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerUpdate : MonoBehaviour 
{
	public SpawnerManager manager = null;
	private float currentTime = 0f;

	// Update is called once per frame
	void Update () 
	{
		if (BallManager.Instance.balls.Count < BallManager.Instance.maxBalls)
		{
			currentTime += Time.deltaTime;
			if (currentTime > manager.period)
			{
				currentTime -= manager.period;
				var ball = Instantiate(manager.prefab, transform.position, Quaternion.identity);
				ball.transform.parent = this.transform;
				BallManager.Instance.balls.Add(ball);
			}
		}
	}
}
