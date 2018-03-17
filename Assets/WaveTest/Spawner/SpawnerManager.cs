using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour 
{
	public GameObject prefab = null;
	public float period = 0.5f;

	void Awake () 
	{
		if (BallManager.Instance.type == ESpawnerType.COROUTINE)
		{
			var s = gameObject.AddComponent<SpawnerCoroutine>();
			s.manager = this;
		}
		else
		{
			var s = gameObject.AddComponent<SpawnerUpdate>();
			s.manager = this;
		}
	}
}
