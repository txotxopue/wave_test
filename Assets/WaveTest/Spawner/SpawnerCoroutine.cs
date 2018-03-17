using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoroutine : MonoBehaviour 
{
	public SpawnerManager manager = null;

	// Use this for initialization
	void Start () 
	{
        StartCoroutine("Spawn");
	}
	
	IEnumerator Spawn() 
	{
		while(BallManager.Instance.balls.Count < BallManager.Instance.maxBalls)
		{
			var ball = Instantiate(manager.prefab, transform.position, Quaternion.identity);
			BallManager.Instance.balls.Add(ball);
			ball.transform.parent = this.transform;
			yield return new WaitForSeconds(manager.period);
		}
    }
}
