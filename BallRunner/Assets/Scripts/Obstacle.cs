using UnityEngine;
using GameManagerSpace;

public class Obstacle : MonoBehaviour
{
    public float rotationSpeed=60f;

    //function to destroy obstacle on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            return;
        }
        GameManager.inst.DecrementLives();
        Destroy(gameObject);
    }

    //rotation every frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
