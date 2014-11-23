using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject prefabToSpawn;
	public float startDelay;
	public float timeBetweenWaves;
	public float timeBetweenSpawns;
	public int spawnsPerWave;
	public int currentWave;

	// Use this for initialization
	void Start () {
		currentWave = 0;
		StartCoroutine(SpawnLoop());
	}
	
	IEnumerator SpawnLoop()
	{
		yield return new WaitForSeconds(startDelay);
		while(true)
		{
			currentWave += 1;
			for (int i = 0; i < spawnsPerWave; i++)
			{
				Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
				yield return new WaitForSeconds(timeBetweenSpawns);
			}
			yield return new WaitForSeconds(timeBetweenWaves);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
