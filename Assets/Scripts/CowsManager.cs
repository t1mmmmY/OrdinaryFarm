using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CowsManager : BaseSingleton<CowsManager> 
{
	[Range(1, 200)]
	[SerializeField] int cowsCount = 50;

	[SerializeField] CowMind cowPrefab;

	List<CowMind> allCows;

	protected override void Awake ()
	{
		base.Awake ();
	}

	public void Init()
	{
		allCows = new List<CowMind>();

		Factory.Instance.CreateObjectsAsync<CowMind>(cowPrefab, cowsCount, OnCreateCow, OnFinishCreating);
	}

	void OnCreateCow(CowMind cow)
	{
		cow.transform.parent = this.transform;
		AddCow(cow);
	}

	void OnFinishCreating()
	{
		Debug.Log("All cows created");
	}

	void AddCow(CowMind cow)
	{
		allCows.Add(cow);
	}

	public List<CowMind> GetAllCowsInRadius(Vector3 position, float radius)
	{
		var cowsInRadius = from cow in allCows
							where Vector3.Distance(cow.transform.position, position) <= radius
							select cow;

		List<CowMind> cows = new List<CowMind>();
		foreach (CowMind cow in cowsInRadius)
		{
			cows.Add(cow);
		}

		return cows;
	}

	public List<CowMind> GetAllCowsInRadius(Vector3 position, float radius, List<CowMind> followedCows)
	{
		if (allCows == null)
		{
			return new List<CowMind>();
		}

		var cowsInRadius = from cow in allCows
							where !followedCows.Contains(cow) && Vector3.Distance(cow.transform.position, position) <= radius
							select cow;
		
		List<CowMind> cows = new List<CowMind>();
		foreach (CowMind cow in cowsInRadius)
		{
			cows.Add(cow);
		}
		
		return cows;
	}

}
