using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to handle the actions which a given unit can take.

public class PlayerActions : MonoBehaviour
{
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Whether the unit can be activated.
    public bool IsActive()
    {
        return true;
    }

    public void MoveTo(MoveTarget tile)
    {
        this.gameObject.transform.position = tile.gameObject.transform.position + offset;
    }
}
