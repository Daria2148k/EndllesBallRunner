using UnityEngine;
using System.Collections;

public class Player_Control : MonoBehaviour
{
	public Camera mainCam;

	public bool alive=true;
	public float speed;
	public float swipeSpeed;

	//setSpeed for linear interpolation of speed
	float setSpeed;

	[SerializeField] Rigidbody rb;

	public float speedIncrVal;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		speed = 8f;
		swipeSpeed = 50f;
		setSpeed = speed;
	}

	//basic player control
    void FixedUpdate()
    {
        if (!alive) return;

		if (Input.GetMouseButton(0))
		{
			//movePosition for forward move 
			Vector3 moveForward = transform.forward * speed * Time.fixedDeltaTime;
			rb.MovePosition(rb.position + moveForward);

			float mouseXval = Input.GetAxis("Mouse X");

			//clamping mouse input incase of accidental fast movement
			mouseXval = Mathf.Clamp(mouseXval, -1, 1);

			Vector3 force = new Vector3(mouseXval, 0.0f, 0.0f);

			//addForce for x-axis movement for more gradual movement
			rb.AddForce(force * swipeSpeed);
		}
		else
		{
			//immideatly pausing force without pressing
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.Sleep();
		}
	}

	//coroutine for gradual speed increase
	public IEnumerator speedIncrease()
	{
		float time = 0;
		while (time < 3)
		{
			speed = Mathf.Lerp(speed,setSpeed*speedIncrVal,time/3);
			
			time += Time.deltaTime;
			yield return null;
		}
	}

}
