using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_Spawn : MonoBehaviour {

    #region Variables
    // public
    public float spawnRate;
    public float spawnRadius;
    // private
    [SerializeField]
    private GameObject platform;
    private Vector2 spawnPoint;
    private Coroutine spawnCoroutine = null;
    #endregion

    #region Unity Methods
    private void Start()
    {
        spawnCoroutine = StartCoroutine(Spawn(spawnRate));
    }
    // Update is called once per frame
    private void Update () {
        CheckSpawns();
	}
	#endregion
	
	#region My Methods
    void SpawnPlatform()
    {
        spawnPoint = (Random.insideUnitCircle * spawnRadius) + new Vector2(transform.position.x, transform.position.y);        
        GameObject ins = Instantiate(platform, new Vector3(spawnPoint.x, spawnPoint.y), Quaternion.identity) as GameObject;
    }

    IEnumerator Spawn(float timeToSpawn)
    {
        yield return new WaitForSeconds(timeToSpawn);
        SpawnPlatform();
        spawnCoroutine = null;
    }

    void CheckSpawns()
    {
        if(spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(Spawn(spawnRate));
        }
    }

    void StopSpawning()
    {
        if(spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }        
    }
    #endregion
}