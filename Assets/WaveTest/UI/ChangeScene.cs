using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour 
{
	public void LoadUpdate()
	{
		SceneManager.LoadScene("Update");
	}

	public void LoadCollider()
	{
		SceneManager.LoadScene("Collider");
	}

	public void Quit()
	{
		Application.Quit();
	}

}
