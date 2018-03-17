using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpUpdate : MonoBehaviour {

	[SerializeField]
	private int maxRadius = 50;
	[SerializeField]
	private int growDuration = 2;

	private List<GameObject> balls = null;

	private int currentBallIndex = 0;
	private float currentTime = 0f;

	private bool active = false;
	
	void Update() 
	{
		if (active == false) 
		{
			if (Input.GetKeyDown(KeyCode.Space)) Activate();
		}
		if (active == true)
		{
			currentTime += Time.deltaTime;
			float targetTime = 0f;
			// There might be many balls to change each frame.
			do
			{
				// End the state if the powerup effect has ended or there are no more balls.
				if (currentTime > growDuration || currentBallIndex >= balls.Count)
				{
					active = false;
					break;	
				} 
				// Get the ball, calculate the distance and change the color.
				var ball = balls[currentBallIndex];
				targetTime = (GetDistance(ball)/maxRadius) * growDuration;
				ball.GetComponent<ColorChanger>().ChangeColor();
				currentBallIndex++;
			} while (currentTime >= targetTime);
		}
	}

	public void Activate()
	{
		// Sort balls.
		balls = BallManager.Instance.balls;
		balls.Sort(new Comparison<GameObject>(Sorter));
		// Change the state.
		active = true;
		currentTime = 0;
	}

	private int Sorter(GameObject goA, GameObject goB)
	{
		if (GetDistance(goA) < GetDistance(goB)) 
		{
			return -1;
		} 
		else if (GetDistance(goA) > GetDistance(goB))
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}

	private float GetDistance(GameObject t) 
	{
		return (t.transform.position - this.transform.position).magnitude;
	}
}
