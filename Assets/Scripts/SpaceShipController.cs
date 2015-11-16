using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceShipController : MonoBehaviour 
{
	[SerializeField] float speed = 2.0f;
	[SerializeField] float radius = 2.0f;
	[SerializeField] Transform targetPoint;
	[SerializeField] SpaceShipAnimationController spaceShipAnimation;
	

	List<CowMind> followedCows;

	bool isActive = false;
	float deltaTime = 0.5f;


	public void ActivateControl()
	{
		if (!isActive)
		{
			isActive = true;
			InputManager.onClick += OnClick;
			spaceShipAnimation.Activate();
		}
	}

	public void DeactivateControl()
	{
		if (isActive)
		{
			isActive = false;
			InputManager.onClick -= OnClick;
			spaceShipAnimation.Deactivate();
		}
	}

	void OnEnable()
	{
		followedCows = new List<CowMind>();

		StartCoroutine("CustomUpdate");
	}

	void OnDisable()
	{
		StopCoroutine("CustomUpdate");
	}

	IEnumerator CustomUpdate()
	{
		do
		{
			FindNearestCows();
			yield return new WaitForSeconds(deltaTime);
			
		} while (true);
	}

	void OnClick(Vector3 position)
	{
		MoveTo(position);
	}

	void FindNearestCows()
	{
		List<CowMind> cows = CowsManager.Instance.GetAllCowsInRadius(transform.position, radius, followedCows);

		foreach (CowMind cow in cows)
		{
			cow.StartFollowing(targetPoint);
			followedCows.Add(cow);
		}
	}

	void MoveTo(Vector3 position)
	{
		Hashtable hash = new Hashtable();
		hash.Add("position", position);
		hash.Add("easetype", iTween.EaseType.easeInOutSine);
		hash.Add("speed", speed);

		iTween.MoveTo(this.gameObject, hash);
	}

}
