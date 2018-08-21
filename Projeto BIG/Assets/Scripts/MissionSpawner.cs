using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSpawner : MonoBehaviour {

    #region Declaring variables
    //Main Variables
    [SerializeField] private GameObject lowMission;
    [SerializeField] private GameObject highMission;

    //"Where to spawn" variables
    private PolygonCollider2D spawnRegionCol;
    private Vector3 spawnRegionPoint;
    private Vector3 highSpawnRegionPoint;

    //Bool to keep one coroutine always working
    private bool lowMissionCheck = true;
    private bool highMissionCheck = true;

    //offsets to spawn the missions
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;


    #endregion

    #region Start (setting variables)
    void Start () {
        spawnRegionCol = GetComponentInParent<PolygonCollider2D>();
	}
    #endregion
    #region Update
    void Update () {
        SpawnMission();
	}
    #endregion
    #region SpawnMission function and coroutines
    void SpawnMission()
    {
        if (lowMissionCheck)
        {
            /// Place to create the coroutine
            lowMissionCheck = false;
            StartCoroutine(SpawnLowMission());
        }

        if (highMissionCheck)
        {
            highMissionCheck = false;
            StartCoroutine(SpawnHighMission());
        }
    }

    /////////// Coroutines
    IEnumerator SpawnLowMission()
    {
        yield return new WaitForSeconds(Random.Range(1,2));
        // Instanciando a missao como um gameobject no canvas
        GameObject lowMissionSpawn = Instantiate(lowMission) as GameObject;
        
        spawnRegionPoint = new Vector3(Random.Range(transform.position.x - xOffset, transform.position.x + xOffset),
        Random.Range(transform.position.y - yOffset, transform.position.y + yOffset), 2);
        lowMissionSpawn.transform.position = spawnRegionPoint;

        while (!spawnRegionCol.OverlapPoint(spawnRegionPoint)) //Caso o objeto tenha sido colocado fora do lugar, isso vai fazer spawnar até aparecer dentro
        {
            spawnRegionPoint = new Vector3(Random.Range(transform.position.x - xOffset, transform.position.x + xOffset),
            Random.Range(transform.position.y - yOffset, transform.position.y + yOffset), 2);
            lowMissionSpawn.transform.position = spawnRegionPoint;
        }


        lowMissionSpawn.transform.SetParent(gameObject.transform);
        
        lowMissionCheck = true;
    }
    IEnumerator SpawnHighMission() //Copia do low level, mas com algumas alteracoes pra se adequar
    {
        yield return new WaitForSeconds(Random.Range(0, 1));
        // Instanciando a missao como um gameobject no canvas
        GameObject highMissionSpawn = Instantiate(highMission) as GameObject;
        
        highSpawnRegionPoint = new Vector3(Random.Range(transform.position.x - xOffset, transform.position.x + xOffset),
        Random.Range(transform.position.y - yOffset, transform.position.y + yOffset), 2);
        highMissionSpawn.transform.position = highSpawnRegionPoint;

        while(!spawnRegionCol.OverlapPoint(highSpawnRegionPoint))
        {
            highSpawnRegionPoint = new Vector3(Random.Range(transform.position.x - xOffset, transform.position.x + xOffset),
            Random.Range(transform.position.y - yOffset, transform.position.y + yOffset), 2);
            highMissionSpawn.transform.position = highSpawnRegionPoint;
        }
        highMissionSpawn.transform.SetParent(gameObject.transform);

        highMissionCheck = true;
    }
    #endregion
}
