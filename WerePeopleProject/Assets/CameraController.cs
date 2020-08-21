using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float rotationSens;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(KeyCode.UpArrow) && !(transform.position.y > 7.6))
        {
            transform.Translate(Vector3.up * rotationSens);
        }
        if (Input.GetKey(KeyCode.DownArrow) && !(transform.position.y < 1))
        {
            transform.Translate(Vector3.down * rotationSens);
        }
        if (Input.GetKey(KeyCode.RightArrow) && !(transform.position.z > 0 && transform.position.x > 0)){
            transform.Translate(Vector3.right * rotationSens);
            Debug.Log(transform.position);
        }
        
          if (Input.GetKey(KeyCode.LeftArrow) && !(transform.position.z > 0 && transform.position.x < 0)){
            transform.Translate(Vector3.left * rotationSens);
            Debug.Log(transform.position);
        }
        transform.LookAt(target);
    }
}
