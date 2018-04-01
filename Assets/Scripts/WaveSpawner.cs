using System.Collections;
//Allows us to reference UI obj
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    //Enemy type/graphic
    public Transform enemyPrefab;

    //where it spawns
    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;
    private float countdown = 2f;

    public Text WaveCountdownText;

    private int waveIndex = 0;

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        //counts down timer per second
        countdown = countdown - Time.deltaTime;

        //Mathf.Floor cuts off all but one empty decimal place!
        //Mathf.Round basically does the same thing, but doesnt skip the first number on cycle
        //(Have to switch between .Floor and .Round to understand what Im talking about
        WaveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    //IEnumerator allows for this section of code to be paused, allowing spacing between
    //Enemies on spawn
    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming!");
        waveIndex++;
        //numOfEnemies = waves[waveNumber].count;
        //OR numOfEnemies = waveNumber * waveNumber + 1;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
