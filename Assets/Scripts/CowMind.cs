using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class CowMind : MonoBehaviour 
{
	[SerializeField] CowAnimationController cowAnimation;

	Transform target;
	bool isFollow = true;
	NavMeshAgent navMeshAgent;

	bool getTheDestination = false;

	void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		if (navMeshAgent == null)
		{
			Debug.LogError("It's shouldn't happened, Nav mesh agent was not found!");
		}

	}

	public void StartFollowing(Transform target)
	{
		if (getTheDestination)
		{
			return;
		}

		this.target = target;
		StartCoroutine("FollowTarget");
		cowAnimation.StartAnimation();
	}

	public void StopFollowing()
	{
		StopCoroutine("FollowTarget");
		cowAnimation.StopAnimation();
	}

	public void ReachTheDestination()
	{
		StopFollowing();
		getTheDestination = true;
	}

	IEnumerator FollowTarget()
	{
		do
		{
			navMeshAgent.SetDestination(target.position);
			cowAnimation.SetDirection(new Vector2(navMeshAgent.velocity.x, navMeshAgent.velocity.z));

			yield return new WaitForSeconds(0.1f);

			if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
			{
				cowAnimation.StopAnimation();
			}
			else
			{
				cowAnimation.StartAnimation();
			}

		} while (true);
	}

}
