using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
	[SerializeField] Camera mainCamera;

	public static System.Action<Vector3> onClick;
	public static System.Action<SpaceShipController> onSelectSpaceShip;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Click();
		}
	}

	void Click()
	{
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit))
		{
			SpaceShipController spaceShip = hit.collider.GetComponent<SpaceShipController>();

			if (spaceShip != null) //Select another SpaceShip
			{
				if (onSelectSpaceShip != null)
				{
					onSelectSpaceShip(spaceShip);
				}
			}
			else //Click on the ground
			{
				if (onClick != null)
				{
					onClick(hit.point);
				}
			}
		}
	}

}
