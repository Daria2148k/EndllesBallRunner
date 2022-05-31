using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    //usual camera movement scipt to follow the player
    [SerializeField] Transform player;

    Vector3 offset;


    void Start()
    {
        offset = transform.position - player.position;
    }

    
    void Update()
    {
        Vector3 targetPos= transform.position = player.position + offset;
        transform.position = targetPos;
    }
}
