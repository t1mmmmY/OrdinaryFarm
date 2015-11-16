using UnityEngine;
using System.Collections;

public class LevelManager : BaseSingleton<LevelManager> 
{
	[SerializeField] Vector2 _levelSize;

	public Vector2 levelSize
	{
		get { return _levelSize; }
	}
}
