using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceShipsManager : BaseSingleton<SpaceShipsManager> 
{
	[Range(1, 10)]
	[SerializeField] int spaceShipsCount = 3;
	[SerializeField] SpaceShipController spaceShipPrefab;

	[SerializeField] List<SpaceShipController> allSpaceShips;
	

	public void Init()
	{
		allSpaceShips = new List<SpaceShipController>();
		InputManager.onSelectSpaceShip += OnSelectSpaceShip;

		Factory.Instance.CreateObjectsAsync<SpaceShipController>(spaceShipPrefab, spaceShipsCount, OnCreateSpaceShip, OnFinishCreating);
	}

	public void OnDestroy()
	{
		InputManager.onSelectSpaceShip -= OnSelectSpaceShip;
	}


	void OnCreateSpaceShip(SpaceShipController spaceShip)
	{
		spaceShip.transform.parent = this.transform;
		spaceShip.DeactivateControl();
		AddSpaceShip(spaceShip);
	}

	void OnFinishCreating()
	{
		Debug.Log("All Space Ships created");

		SelectSpaceShip(0);
	}

	void AddSpaceShip(SpaceShipController spaceShip)
	{
		allSpaceShips.Add(spaceShip);
	}

	void OnSelectSpaceShip(SpaceShipController spaceShip)
	{
		SelectSpaceShip(allSpaceShips.IndexOf(spaceShip));
	}

	public bool SelectSpaceShip(int number)
	{
		if (number >= allSpaceShips.Count)
		{
			Debug.LogWarning("number >= allSpaceShips.Count");
			return false;
		}

		for (int i = 0; i < allSpaceShips.Count; i++)
		{
			if (i == number)
			{
				allSpaceShips[i].ActivateControl();
			}
			else
			{
				allSpaceShips[i].DeactivateControl();
			}
		}

		return true;
	}

}
