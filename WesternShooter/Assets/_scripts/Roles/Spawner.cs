using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject Spawnable;
    public float SpawnIntervalInSeconds;
    public float spawnCapacity;

    private Timer spawnTimer;


	void Awake () {
        spawnTimer = new Timer(SpawnIntervalInSeconds, true);
	}
	
	void Update () {
        if(spawnCapacity <= 0)
        {
            return;
        }

        spawnTimer.TickTimer(Time.deltaTime);
        if (spawnTimer.IsDone())
        {
            SpawnEnemy();
            spawnTimer.Restart();
        }
	}


    public void SpawnEnemy()
    {
        GameObject spawned = Instantiate(Spawnable, this.transform.position, this.transform.rotation);
        spawned.name +=  " " + Random.Range(0,99999);
        spawnCapacity--;
    }
}