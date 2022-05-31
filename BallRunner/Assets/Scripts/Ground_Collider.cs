using UnityEngine;

public class Ground_Collider : MonoBehaviour
{
    //referencing spawned tile
    Ground_Spawn groundSpawn;

    [SerializeField] GameObject SpeedPointPrefab;
    [SerializeField] GameObject ObstaclePrefab;

 
    void Start()
    {
        groundSpawn = GameObject.FindObjectOfType<Ground_Spawn>();
    }

    //spawning objects with basic random comparison on collision and destroying after 3sec
    private void OnTriggerExit(Collider other)
    {
        bool randomBoolObst = Random.value > 0.9;
        bool randomBoolPoints = Random.value > 0.8;
        groundSpawn.tileSpawn(randomBoolObst, randomBoolPoints);

        Destroy(gameObject, 3);
    }

    //points spawner at randon within tile collider
    public void PointSpawn()
    {
        GameObject tempPosPoints = Instantiate(SpeedPointPrefab, transform);
        tempPosPoints.transform.position = RandomPoint(transform.GetChild(0).GetComponent<Collider>());
    }

    //obstacle spawner at randon within tile collider
    public void ObstacleSpawn()
    {
        
        GameObject tempPosObstacles = Instantiate(ObstaclePrefab,transform);
        tempPosObstacles.transform.position = RandomPoint(transform.GetChild(0).GetComponent<Collider>());
        
    }

    //basic randon pointa generator within bounds
    Vector3 RandomPoint(Collider collider)
    {
        Vector3 randomVec = new Vector3(
            Random.Range(collider.bounds.min.x+1, collider.bounds.max.x-1),1,
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        //precautios check
        if (randomVec != collider.ClosestPoint(randomVec))
        {
            randomVec = RandomPoint(collider);
        }

        return randomVec;
    }
}
