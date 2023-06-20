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
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(18, 0, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(18, 0, 0);
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x < 0 && pm.moveDir.y == 0) //left
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(-18, 0, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(-18, 0, 0);
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x == 0 && pm.moveDir.y > 0) //up
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, 18, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(0, 18, 0);
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x == 0 && pm.moveDir.y < 0) //down
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, -18, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(0, -18, 0);
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x > 0 && pm.moveDir.y > 0) //right up
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(18, 18, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(18, 18, 0);
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x > 0 && pm.moveDir.y < 0) //right down
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(18, -18, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(18, -18, 0);
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x > 0 && pm.moveDir.y > 0) //left up
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(-18, 18, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(-18, 18, 0);
                SpawnChunck();
            }
        }
        else if(pm.moveDir.x < 0 && pm.moveDir.y < 0) //left down
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(-18, -18, 0), checkRadius, terrainMask)) 
            {
                noTerrainPosition = player.transform.position + new Vector3(-18, -18, 0);
                SpawnChunck();
            }
        }
    }

    void SpawnChunck() 
    {

        int rand = Random.Range(0, terrainChuncks.Count);
        Instantiate(terrainChuncks[rand], noTerrainPosition, Quaternion.identity);

    }
}
