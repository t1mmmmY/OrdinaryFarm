using UnityEngine;
using System.Collections;

public class SpaceShipAnimationController : MonoBehaviour 
{
	Animator animator;

	int isActiveKeyHash = Animator.StringToHash("IsActive");
	
	
	void Start()
	{
		animator = GetComponent<Animator>();
		if (animator == null)
		{
			Debug.LogError("It's shouldn't happened, Animator was not found!");
		}
	}

	public void Activate()
	{
		animator.SetBool(isActiveKeyHash, true);
	}
	
	public void Deactivate()
	{
		animator.SetBool(isActiveKeyHash, false);
	}

}
