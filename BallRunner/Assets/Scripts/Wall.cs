using UnityEngine;
using GameManagerSpace;

public class Wall : MonoBehaviour
{
    //decrease lives on collision with wall
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Player")
        {
            return;
        }
        GameManager.inst.DecrementLives();
    }


}
