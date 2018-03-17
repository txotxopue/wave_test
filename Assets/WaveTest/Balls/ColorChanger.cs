using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour 
{
	private static readonly Color newColor = new Color(1, 0, 0);
	private Material material = null;

	// Use this for initialization
	private void Start () 
	{
		material = GetComponent<Renderer>().material;
	}

	public void ChangeColor() 
	{
		if (null != material)
		{
			material.color = newColor;
		}
	}
}
