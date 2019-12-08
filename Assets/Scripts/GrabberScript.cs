using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GrabberScript : MonoBehaviour
{
	public bool grabbed;
	RaycastHit2D hit;
	public float distance = 2f;
	public Transform holdPoint;
	public float throwforce;
	public LayerMask notgrabbed;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
		if(CrossPlatformInputManager.GetButton("Interact") && grabbed)
		{
			if(hit.collider.gameObject.GetComponent<Rigidbody2D>()!=null)
				{
					Vector2 movement = new Vector2(Input.acceleration.x , Input.acceleration.y)*throwforce;
					hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = movement;
					grabbed=false;
				}
		}
		
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
				
			}else if(!Physics2D.OverlapPoint(holdPoint.position,notgrabbed))
			{
				grabbed=false;
				
				if(hit.collider.gameObject.GetComponent<Rigidbody2D>()!=null)
				{
					hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity= new Vector2(transform.localScale.x,1)*throwforce;
				}
			}
		}

		if (grabbed)
		{
			hit.collider.gameObject.transform.position = holdPoint.position;
		}
    }
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position,transform.position+Vector3.right*transform.localScale.x*distance);
	}
}
