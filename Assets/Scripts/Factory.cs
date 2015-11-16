using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Factory : BaseSingleton<Factory>
{
	//Create all objects at one frame
	public List<T> CreateObjects<T>(T prefab, int count) where T : MonoBehaviour
	{
		List<T> listOfObjects = new List<T>();

		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < count / 100.0f; j++)
			{
				listOfObjects.Add(CreateObject(prefab, GetRandomPosition()));
			}
		}

		return listOfObjects;
	}

	//Separate objects creation to some period of time
	public void CreateObjectsAsync<T>(T prefab, int count, System.Action<T> callbackOnCreateObject, System.Action callbackOnFinish) where T : MonoBehaviour
	{
		StartCoroutine(CreateObjectsCoroutine<T>(prefab, count, callbackOnCreateObject, callbackOnFinish));
	}


	IEnumerator CreateObjectsCoroutine<T>(T prefab, int count, System.Action<T> callbackOnCreateObject, System.Action callbackOnFinish) where T : MonoBehaviour
	{
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < count / 100.0f; j++)
			{
				T obj = CreateObject(prefab, GetRandomPosition());

				if (callbackOnCreateObject != null)
				{
					callbackOnCreateObject(obj);
				}
			}
			
			yield return new WaitForEndOfFrame();
		}

		if (callbackOnFinish != null)
		{
			callbackOnFinish();
		}
	}


	T CreateObject<T>(T prefab, Vector3 position) where T : MonoBehaviour
	{
		T obj = GameObject.Instantiate<T>(prefab);
		obj.transform.position = position;
		
		return obj;
	}
	
	Vector3 GetRandomPosition()
	{
		Vector2 levelSize = LevelManager.Instance.levelSize;
		return new Vector3(Random.Range(-levelSize.x / 2.0f, levelSize.x / 2.0f),
		                   0,
		                   Random.Range(-levelSize.y / 2.0f, levelSize.y / 2.0f));
	}
	

}
