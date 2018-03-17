using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : Singleton<BallManager> {
	public int maxBalls = 6000;

	public ESpawnerType type = ESpawnerType.COROUTINE;

	public List<GameObject> balls = new List<GameObject>();
}
