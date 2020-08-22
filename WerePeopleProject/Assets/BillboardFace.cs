using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardFace : MonoBehaviour
{  public Camera m_Camera;
	public bool amActive =false;
	public bool autoInit =false;
	public float wiggle;
	GameObject myContainer;	
 
	void Awake(){
		if (autoInit == true){
			m_Camera = Camera.main;
			amActive = true;
		}
 
		myContainer = new GameObject();
		myContainer.transform.parent = transform.parent;
		myContainer.name = "GRP_"+transform.gameObject.name;
		myContainer.transform.position = transform.position;
		transform.parent = myContainer.transform;
	}
 
    //Orient the camera after all movement is completed this frame to avoid jittering
    void Update(){
        if(amActive==true){
        	myContainer.transform.LookAt(myContainer.transform.position + m_Camera.transform.rotation * Vector3.back, m_Camera.transform.rotation * Vector3.up);
			myContainer.transform.Rotate(Vector3.forward, wiggle);
	    }
    }
}