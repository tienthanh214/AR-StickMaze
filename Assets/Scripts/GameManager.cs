using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance = null;

	public int nInitialStickman = 5;

	public GameObject stickman;
	private List<GameObject> stickmanAlive = new List<GameObject>();
	public static GameManager instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("GameManager must be initialized");
			return _instance;
		}
	}

	private void Awake()
	{
		if (_instance != null)
		{
			Destroy(gameObject);
		}
		_instance = this;

		DontDestroyOnLoad(gameObject);

		InitGame();
	}

	private void InitGame()
	{
		// GenerateStickman(stickman, nInitialStickman, Vector3.zero);
	}

	public void GenerateStickman(GameObject stickman, int n, Vector3 position, Vector3 scaleVector)
	{
		for (int i = 0; i < n; ++i)
		{
			float biasX = Random.Range(-0.1f, 0.1f);
			float biasZ = Random.Range(-0.1f, 0.1f);
			GameObject myModelTrf = Instantiate(stickman, new Vector3(position.x + biasX, position.y, position.z + biasZ), Quaternion.identity) as GameObject;
			// myModelTrf.transform.localScale = scaleVector;
			stickmanAlive.Add(myModelTrf);
		}
	}

	public void ResetGame()
	{
		for (int i = 0; i < stickmanAlive.Count; ++i)
		{
			Destroy(stickmanAlive[i]);
		}
		stickmanAlive.Clear();
	}

	public void RemoveStickman(GameObject obj)
    {
		if (obj != null)
		{
			stickmanAlive.Remove(obj);
			Destroy(obj);
		}
    }
}
