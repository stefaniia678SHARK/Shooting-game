using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Diagnostics;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int numOfEnemies;
    public GameObject[] typeofEnemies;
    public float spawnInterval;
}


public class wave_spawner : MonoBehaviour
{
 
    public Wave[] waves; // array of waves
    public Transform[] spawnPoints; // array of enemies int this wave

    //to know at each wave you are in
    private Wave currentWave;
    private int currentWaveNumber = 0;
    private float nextSpawntime = 0;
    private int remainingEnemies; // track the remaining enemies in the current wave
    private bool canSpawn = true;

    public HealthBar healthBar;  // reference to the HealthBar

/*    public string intermissionScene = "Between wave"; // name of the scene to load after each wave
    public string gameScene = "SampleScene";

    private static wave_spawner instance;*/

/*    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // makes the script persistent between scenes
        }
        else
        {
            Destroy(gameObject); // ensures only one instance exists
        }
    }*/

    private void Start()
    {
        currentWave = waves[currentWaveNumber];
        remainingEnemies = currentWave.numOfEnemies; // copy numOfEnemies for each wave
    }
    private void Update()
    {
        //Debug.Log("Update is running...");

        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("enemy");
        GameObject[] totalEnemies2 = GameObject.FindGameObjectsWithTag("boss");
        if (totalEnemies.Length == 0 && totalEnemies2.Length == 0 && !canSpawn && currentWaveNumber + 1 != waves.Length) //to switch to another wave need to kill all enemies
        {
            if (currentWaveNumber + 1 < waves.Length)
            {
               // Debug.Log("Starting Next Wave...");
                SpawnNextWave();
            }
            else
            {
                //Debug.Log("All Waves Completed! Loading Scene 3...");
                SceneManager.LoadScene(3);
            }
        }

    }

/*    IEnumerator LoadSampleScene()
    {
        yield return new WaitForSeconds(0.5f); // wait 2 seconds before switching
        SceneManager.LoadScene(intermissionScene);
        yield return new WaitForSeconds(2f); // stay on the intermission scene for 3 seconds
        SceneManager.LoadScene(gameScene);
        yield return new WaitForEndOfFrame();
        SpawnNextWave();
    }*/

    void SpawnNextWave()
    {
        currentWaveNumber++;
        if (currentWaveNumber < waves.Length)
        {
            currentWave = waves[currentWaveNumber];
            remainingEnemies = currentWave.numOfEnemies; // reset the count for the new wave
            canSpawn = true;
        }
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawntime <= Time.time)
        {
            //Debug.Log("Function is working");

            // random enemies at a random spot
            GameObject randomEnemy = currentWave.typeofEnemies[Random.Range(0, currentWave.typeofEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemyInstance = Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);

            // if enemy is boss we will see health bar

            if (enemyInstance.CompareTag("boss"))
            {
                EnemyBoss boss = enemyInstance.GetComponent<EnemyBoss>();

                if (healthBar != null)
                {
                    boss.healthBar = healthBar; // assign health bar to the boss
                    boss.healthBar.SetMaxHealth(boss.maxHealth);  // set max health
                    boss.healthBar.gameObject.SetActive(true); // 
                }
            }

            remainingEnemies--; // modify the local copy instead of the original wave array
            nextSpawntime = Time.time + currentWave.spawnInterval;

            if (remainingEnemies == 0)
            {
                
                canSpawn = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            // stop spawning new enemies
            canSpawn = false;

            //SceneManager.LoadScene("3");
        }
    }
}
