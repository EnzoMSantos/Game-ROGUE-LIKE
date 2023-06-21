using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public List<GameObject> terrainChuncks;
    public GameObject player;
    public float checkRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    PlayerMovement pm;
    public float distance_positive = 5;
    public float distance_negative = -5;



    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunckChecker();
    }

    void ChunckChecker() 
    {

        if(pm.moveDir.x > 0 && pm.moveDir.y == 0) //right
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(distance_positive, 0, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(distance_positive, 0, 0);
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x < 0 && pm.moveDir.y == 0) //left
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(distance_negative, 0, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(distance_negative, 0, 0);
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x == 0 && pm.moveDir.y > 0) //up
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, distance_positive, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(0, distance_positive, 0);
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x == 0 && pm.moveDir.y < 0) //down
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, distance_negative, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(0, distance_negative, 0);
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x > 0 && pm.moveDir.y > 0) //right up
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(distance_positive, distance_positive, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(distance_positive, distance_positive, 0);
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x > 0 && pm.moveDir.y < 0) //right down
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(distance_positive, distance_negative, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(distance_positive, distance_negative, 0);
                SpawnChunck();
            }
        }
       else if(pm.moveDir.x < 0 && pm.moveDir.y > 0) //left up
{
        if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(distance_negative, distance_positive, 0), checkRadius, terrainMask)) 
        {
            noTerrainPosition = player.transform.position + new Vector3(distance_negative, distance_positive, 0);
            SpawnChunck();
        }
}
        else if(pm.moveDir.x < 0 && pm.moveDir.y < 0) //left down
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(distance_negative, distance_negative, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(distance_negative, distance_negative, 0);
                SpawnChunck();
            }
        }
    }

    void SpawnChunck()
   {
    int rand = Random.Range(0, terrainChuncks.Count);
    Vector3 spawnPosition = player.transform.position; // Posição inicial igual à posição do jogador

    if (pm.moveDir.x > 0) {
        spawnPosition += new Vector3(18, 0, 0);
    }
        
    else if (pm.moveDir.x < 0) {
        spawnPosition += new Vector3(-18, 0, 0);
    }
       

    if (pm.moveDir.y > 0) {
        spawnPosition += new Vector3(0, 18, 0);
    }
       
    else if (pm.moveDir.y < 0) {
        spawnPosition += new Vector3(0, -18, 0);
    }
        

    Instantiate(terrainChuncks[rand], spawnPosition, Quaternion.identity);
    }
}
