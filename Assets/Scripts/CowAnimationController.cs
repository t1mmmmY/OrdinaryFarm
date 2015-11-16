using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class CowAnimationController : MonoBehaviour 
{
	Animator animator;

	int horizontalKeyHash = Animator.StringToHash("Horizontal");
	int verticalKeyHash = Animator.StringToHash("Vertical");
	int isMovingKeyHash = Animator.StringToHash("IsMoving");

	void Start()
	{
		animator = GetComponent<Animator>();
		if (animator == null)
		{
			Debug.LogError("It's shouldn't happened, Animator was not found!");
		}
	}


	public void StartAnimation()
	{
		animator.SetBool(isMovingKeyHash, true);
	}
	
	public void StopAnimation()
	{
		animator.SetBool(isMovingKeyHash, false);
	}
	
	public void SetDirection(Vector2 deltaPosition)
	{
		animator.SetFloat(horizontalKeyHash, deltaPosition.x);
		animator.SetFloat(verticalKeyHash, deltaPosition.y);
	}

}
