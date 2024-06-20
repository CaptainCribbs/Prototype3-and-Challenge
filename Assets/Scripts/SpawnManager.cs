using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public Vector3 spawnPos = new Vector3(25, 0, 0);
    public float delay = 2.0f;
    public float interval = 2.0f;
    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", delay, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle(){
        if (playerControllerScript.gameOver == false){
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
    }
}
