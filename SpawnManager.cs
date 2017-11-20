using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public static SpawnManager instance = null;
	[SerializeField] GameObject[] spawnPoints;
	[SerializeField] GameObject virus1;
	[SerializeField] private int enemiesSpawned = 20;
	private float generatedSpawnTime = 1;
	private float currentSpawnTime = 0;
	private GameObject newEnemy;
	private List<VirusMover> enemies = new List<VirusMover>();
	private List<VirusMover> killedEnemies = new List<VirusMover>();
 
 // start the coroutine the usual way but store the Coroutine object that StartCoroutine returns.

 	void Awake(){
		if(instance == null)
		{
			instance = this;
		}

		else if (instance != this)
		{
			Destroy(gameObject);
		}
	 }
	// Use this for initialization
	void Start () {
		StartCoroutine(spawn());
	}
	
	// Update is called once per frame
	void Update () {
		currentSpawnTime += Time.deltaTime;
	}
	public void RegisterEnemy(VirusMover enemy)
	{
		enemies.Add(enemy);
	}

	public void KilledEnemy(VirusMover enemy)
	{
		//enemies.Remove(enemy);
		killedEnemies.Add(enemy);
	}

	
		IEnumerator spawn()
	{
		//check that spawn time is greater than current time
			//if there are less enemies on screen than the current level, randomly select a spawn point
			//and spawn a random enemy
		//if we have killed the same number of enemies as the current level, clear out the enemies 
		//and killed enemies, increment current level by 1, and start over

		if(currentSpawnTime > generatedSpawnTime)
		{
			if(enemies.Count < enemiesSpawned)
			{
				currentSpawnTime = 0;
				int randomNumber = Random.Range(0, spawnPoints.Length - 1);
				GameObject spawnLocation = spawnPoints[randomNumber];
				newEnemy = Instantiate (virus1) as GameObject;
				newEnemy.transform.position = spawnLocation.transform.position;
			}


			/*if(killedEnemies.Count == currentLevel && currentLevel != finalLevel)
			{
				enemies.Clear();
				killedEnemies.Clear();
				yield return new WaitForSeconds(3f);
				currentLevel ++;
				levelText.text = "Level " + currentLevel;
			}

			if(killedEnemies.Count == finalLevel && secondLevel)
			{
				yield return new WaitForSeconds(3f);
				StartCoroutine(endGame("Victory!"));
			}

			else if(killedEnemies.Count == finalLevel && !secondLevel)
			{
				yield return new WaitForSeconds(3f);
				SceneManager.LoadScene("level2");
			}*/

		}
			yield return null;
			StartCoroutine(spawn());
	}
}