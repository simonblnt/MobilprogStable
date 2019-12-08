using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SensorGrabberScript : MonoBehaviour
{
	public bool grabbed;
	RaycastHit2D hit;
	public float distance = 2f;
	public Transform holdPoint;
	public float throwforce;
	public LayerMask notgrabbed;
	public float sensorForce;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {	
		sensorForce = Input.acceleration.x;
        if(CrossPlatformInputManager.GetButtonDown("Interact"))
		{
			if (!grabbed)
			{
				Physics2D.queriesStartInColliders=false;

				hit = Physics2D.Raycast(transform.position, Vector2.right*transform.localScale.x, distance);
				if (hit.collider != null && hit.collider.tag == "Grabbable")
				{
					grabbed = true;
				}
			}
			if (grabbed)
			{
				grabbed = true;
			}
		}

		if (grabbed)
		{
			if (sensorForce > 0.3f || sensorForce < -0.3f)
			{
				grabbed=false;
				
				if(hit.collider.gameObject.GetComponent<Rigidbody2D>()!=null)
				{
					hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity= new Vector2(transform.localScale.x,1)*throwforce;
				}
			}
			else
			{
					hit.collider.gameObject.transform.position = holdPoint.position;
			}
		}
    }
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position,transform.position+Vector3.right*transform.localScale.x*distance);
	}
}
