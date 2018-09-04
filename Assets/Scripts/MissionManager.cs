using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour {
    #region declaring variables
    //Main Variables
    public static MissionManager instance = null;
    [SerializeField] private GameObject lowMission;
    [SerializeField] private GameObject highMission;

    //"Where to spawn" variables
    [SerializeField] private GameObject[] continents;
    [SerializeField] private PolygonCollider2D[] spawnRegionCol;
    private Vector3 spawnRegionPoint;
    private Vector3 highSpawnRegionPoint;

    //Bool to keep one coroutine always working
    private bool lowMissionCheck = true;
    private bool highMissionCheck = true;

    //offsets to spawn the missions
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;

    //keeping track of max mission amount
    [SerializeField] private int maxLowMission = 3;
    [SerializeField] private int maxHighMIssion = 1;
    public int lowMissionCount;
    public int highMissionCount;
    #endregion

    #region void Awake, setando o manager pra persistir por leveis, etc
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Update
    void Update()
    {
        SpawnMission();
    }
    #endregion

    #region SpawnMission function and coroutines
    void SpawnMission()
    {
        if (lowMissionCheck && lowMissionCount < maxLowMission)
        {
            /// Place to create the coroutine
            lowMissionCheck = false;
            StartCoroutine(SpawnLowMission());
        }

        if (highMissionCheck && highMissionCount < maxHighMIssion)
        {
            highMissionCheck = false;
            StartCoroutine(SpawnHighMission());
        }
    }

    /////////// Coroutines
    IEnumerator SpawnLowMission()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        // Instanciando a missao como um gameobject no canvas
        GameObject lowMissionSpawn = Instantiate(lowMission) as GameObject;

        //Adicionando +1 ao mission count
        lowMissionCount++;

        //Vai pegar um continente aleatorio pra spawnar
        int whatContinent = Random.Range(0, continents.Length);
        
        //Definindo o ponto de spawn
        spawnRegionPoint = new Vector3(Random.Range(continents[whatContinent].transform.position.x - xOffset, continents[whatContinent].transform.position.x + xOffset),
        Random.Range(continents[whatContinent].transform.position.y - yOffset, continents[whatContinent].transform.position.y + yOffset), 2);

        lowMissionSpawn.transform.position = spawnRegionPoint;

        while ( !spawnRegionCol[whatContinent].OverlapPoint(spawnRegionPoint)) //Caso o objeto tenha sido colocado fora do lugar, isso vai fazer spawnar até aparecer dentro
        {
            //Definindo o ponto de spawn
            spawnRegionPoint = new Vector3(Random.Range(continents[whatContinent].transform.position.x - xOffset, continents[whatContinent].transform.position.x + xOffset),
            Random.Range(continents[whatContinent].transform.position.y - yOffset, continents[whatContinent].transform.position.y + yOffset), 2);

            lowMissionSpawn.transform.position = spawnRegionPoint;
        }

        lowMissionCheck = true;
        lowMissionSpawn.transform.SetParent(continents[whatContinent].transform);

    }
    IEnumerator SpawnHighMission() //Copia do low level, mas com algumas alteracoes pra se adequar
    {
        highMissionCheck = true;
        yield return new WaitForSeconds(Random.Range(0, 1));
        // Instanciando a missao como um gameobject no canvas
        GameObject highMissionSpawn = Instantiate(highMission) as GameObject;

        //Adicionando +1 ao counter de high
        highMissionCount++;

        //Vai pegar um continente aleatorio pra spawnar
        int whatContinent = Random.Range(0, continents.Length);

        highSpawnRegionPoint = new Vector3(Random.Range(continents[whatContinent].transform.position.x - xOffset, continents[whatContinent].transform.position.x + xOffset),
        Random.Range(continents[whatContinent].transform.position.y - yOffset, continents[whatContinent].transform.position.y + yOffset), 2);
        highMissionSpawn.transform.position = highSpawnRegionPoint;
        
        while (!spawnRegionCol[whatContinent].OverlapPoint(highSpawnRegionPoint))
        {
            highSpawnRegionPoint = new Vector3(Random.Range(continents[whatContinent].transform.position.x - xOffset, continents[whatContinent].transform.position.x + xOffset),
            Random.Range(continents[whatContinent].transform.position.y - yOffset, continents[whatContinent].transform.position.y + yOffset), 2);
            highMissionSpawn.transform.position = highSpawnRegionPoint;
        }
        
        highMissionSpawn.transform.SetParent(continents[whatContinent].transform);
    }
    #endregion


}
