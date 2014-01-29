using UnityEngine;
using System.Collections;


public class playerScript : MonoBehaviour {

	public Camera cam;
	public float dragSpeed = 100.0f;


	private bool inDragMode = false;
	private bool dragCommited = false;
	private Transform bodyPart;
	private Vector3 currentPos = new Vector3(0.0f,0.0f,0.0f);


	void Update () {
		//take mouse position on every update
		Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x * dragSpeed,Input.mousePosition.y * dragSpeed,10.0f));
		// identify you are clicking on body and going in to drag mode
		if(Input.GetMouseButtonDown(0)){
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition),out hit)){
				if(hit.collider.gameObject.tag.Equals("Player")){
					inDragMode = true;
					bodyPart = hit.collider.gameObject.transform;
				}
			}
		}
		// identify you are finished with drag mode
		if(Input.GetMouseButtonUp(0)){
			inDragMode = false;
			dragCommited = false;
		}
		// dragging
		if(inDragMode){
			if(Input.GetMouseButton(0)){
				if(!dragCommited){
					currentPos = mousePos;
					dragCommited = true;
				}
				Vector3 moveDirection = mousePos - currentPos;
				print ("currentPos: " + currentPos + " mousePos: " + mousePos + " moveDirection: " +  moveDirection);
				bodyPart.rigidbody.velocity = moveDirection;
			}
		}

	}
}

