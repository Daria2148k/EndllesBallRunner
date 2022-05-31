using UnityEngine;
using GameManagerSpace;

public class SpeedPoint : MonoBehaviour
{
    float rotationSpeed = 60f;

    //function to collect points and destroy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        
        if (other.gameObject.name != "Player")
        {
            return;
        }

        GameManager.inst.IncrementScore();
        Destroy(gameObject);

    }

    //rotation every frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
