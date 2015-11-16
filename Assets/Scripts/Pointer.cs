using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour 
{

	void OnEnable()
	{
		InputManager.onClick += OnClick;
	}

	void OnDisable()
	{
		InputManager.onClick -= OnClick;
	}

	void OnClick(Vector3 position)
	{
		transform.position = position;
	}

}
