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
    public GameObject currentChunck;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDist;
    float opDist;

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
        
        if(!currentChunck) 
        {
            return;
        }

        if(pm.moveDir.x > 0 && pm.moveDir.y == 0) //right
        {
            if(!Physics2D.OverlapCircle(currentChunck.transform.Find("Right").position, checkRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunck.transform.Find("Right").position;
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x < 0 && pm.moveDir.y == 0) //left
        {
            if(!Physics2D.OverlapCircle(currentChunck.transform.Find("Left").position, checkRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunck.transform.Find("Left").position;
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x == 0 && pm.moveDir.y > 0) //up
        {
            if(!Physics2D.OverlapCircle(currentChunck.transform.Find("Up").position, checkRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunck.transform.Find("Up").position;
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x == 0 && pm.moveDir.y < 0) //down
        {
            if(!Physics2D.OverlapCircle(currentChunck.transform.Find("Down").position, checkRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunck.transform.Find("Down").position;
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x > 0 && pm.moveDir.y > 0) //right up
        {
            if(!Physics2D.OverlapCircle(currentChunck.transform.Find("Right Up").position, checkRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunck.transform.Find("Right Up").position;
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x > 0 && pm.moveDir.y < 0) //right down
        {
            if(!Physics2D.OverlapCircle(currentChunck.transform.Find("Right Down").position, checkRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunck.transform.Find("Right Down").position;
                SpawnChunck();
            }
        }
       else if(pm.moveDir.x < 0 && pm.moveDir.y > 0) //left up
{
        if(!Physics2D.OverlapCircle(currentChunck.transform.Find("Left Up").position, checkRadius, terrainMask)) 
        {
            noTerrainPosition = currentChunck.transform.Find("Left Down").position;
            SpawnChunck();  
        }
}
        else if(pm.moveDir.x < 0 && pm.moveDir.y < 0) //left down
        {
            if(!Physics2D.OverlapCircle(currentChunck.transform.Find("Left Down").position, checkRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunck.transform.Find("Left Down").position;
                SpawnChunck();
            }
        }
    }

    void SpawnChunck()
   {
    int rand = Random.Range(0, terrainChuncks.Count);
     // Posição inicial igual à posição do jogador  
    Instantiate(terrainChuncks[rand], noTerrainPosition, Quaternion.identity);
    }
}
