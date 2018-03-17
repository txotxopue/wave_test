using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUpCollider : MonoBehaviour 
{
	[SerializeField]
	private int maxRadius = 50;
	[SerializeField]
	private int growDuration = 2;

	private SphereCollider trigger = null;

	// Use this for initialization
	void Start () 
	{
		trigger = GetComponent<SphereCollider>();
	}

	void Update() 
	{
		if (Input.GetKeyDown(KeyCode.Space)) Activate();
	}

	public void Activate()
	{
		if (null != trigger) 
		{
			DOTween.To(()=> trigger.radius, x=> trigger.radius = x, maxRadius, growDuration);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		ColorChanger colorChanger = other.gameObject.GetComponent<ColorChanger>();
		if (null != colorChanger)
		{
			colorChanger.ChangeColor();
		}
	}


}
