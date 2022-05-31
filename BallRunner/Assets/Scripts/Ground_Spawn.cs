using UnityEngine;

public class Ground_Spawn : MonoBehaviour
{
    //class to spawn one tile for the track with other objects

    [SerializeField] GameObject tile;

    Vector3 nextSpawn;
    Vector3 scaleSize;

    int numTilesInSeed=30;
    int offset=5;

    
    void Start()
    {
        //spawning objects with basic random comparison
        for (int i = 0; i < numTilesInSeed; i++)
        {
            if (i < offset)
            {
                //not spawnining objects on first 3 tiles
                tileSpawn(false, false);
            }
            else
            {
                bool randomBoolObst = Random.value > 0.9;
                bool randomBoolPoints = Random.value > 0.8;
                tileSpawn(randomBoolObst, randomBoolPoints);
            }
        }
    }

    //function to spawn tile on the spawn point of the previous tile
    public void tileSpawn(bool obstacleSpawnCheck,bool pointsSpawnCheck)
    {
        //scaling tiles at random for divercity
        scaleSize = new Vector3(Random.Range(0.5f, 1f), 1f, 0.1f);
        tile.transform.GetChild(0).transform.localScale = scaleSize;
        
        GameObject tempTile = Instantiate(tile, nextSpawn, Quaternion.identity);
        nextSpawn = tempTile.transform.GetChild(1).transform.position + new Vector3(Random.Range(-0.9f, 0.9f), 0, 0);

        //spawning objects or not, depending on passed bool val
        if (obstacleSpawnCheck)
        {
            tempTile.GetComponent<Ground_Collider>().ObstacleSpawn();
        }
        if (pointsSpawnCheck)
        {
            tempTile.GetComponent<Ground_Collider>().PointSpawn();
        }
    }
}
