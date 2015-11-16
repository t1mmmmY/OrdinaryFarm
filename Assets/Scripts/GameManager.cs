using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{

	void Start()
	{
		StartGame();
	}

	void StartGame()
	{
		SpaceShipsManager.Instance.Init();
		CowsManager.Instance.Init();
	}
}
