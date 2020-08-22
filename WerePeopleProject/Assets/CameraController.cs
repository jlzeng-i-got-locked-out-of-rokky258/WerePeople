using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float rotationSens;

    private double prevHeight = 1;
    private Vector3 tranPosition; 
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(KeyCode.UpArrow) && !(transform.position.y > 6))
        {  
            
            transform.RotateAround(target.transform.position, Vector3.right, 20 * rotationSens);
            if (prevHeight > transform.position.y){
                transform.position = tranPosition;
            }
            else{
                prevHeight = transform.position.y;
                tranPosition = transform.position;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) && !(transform.position.y < 1))
        {
            transform.RotateAround(target.transform.position, Vector3.left, 20 * rotationSens);
            prevHeight = transform.position.y;
            tranPosition = transform.position;
        }
        if (Input.GetKey(KeyCode.RightArrow) && !(transform.position.z > 0 && transform.position.x > 0)){
            transform.RotateAround(target.transform.position, Vector3.down, 20 * rotationSens);
            Debug.Log(transform.position);
        }
        
          if (Input.GetKey(KeyCode.LeftArrow) && !(transform.position.z > 0 && transform.position.x < 0)){
            transform.RotateAround(target.transform.position, Vector3.up, 20 * rotationSens);
            Debug.Log(transform.position);
        }
        transform.LookAt(target);
    }
}
