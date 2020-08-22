using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to handle the actions which a given unit can take.

public class PlayerActions : MonoBehaviour
{

    // Variables related to visual movement.
    private Vector3 offset; // Holds the offset from the moveTarget position.
    private Vector3 targetPosition;
    private Vector3 lastPosition;
    private float percentToTarget;
    private float percentToTargetPerSecond;
    public float moveSpeed = 1f;
    private float secondsToTarget = 1;

    // Variables related to grid positioning.
    private Vector2 gridCoords;
    private bool placedOnGrid = false;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0f, 1f, 0f);
        targetPosition = this.gameObject.transform.position;
        lastPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(lastPosition, targetPosition, percentToTarget);
        //Debug.Log(secondsToTarget);
        percentToTarget = (float) Math.Min(percentToTarget + (1f / secondsToTarget) * Time.deltaTime, 1);
    }

    // Whether the unit can be activated.
    public bool IsActive()
    {
        return true;
    }


    // Should be overridden for children of PlayerActions
    // This default method provides a single tile of movement.
    // CanMoveTo is also used to figure out which grid tiles to highlight for potential movement.
    public bool CanMoveTo(MoveTarget tile)
    {
        Vector2 tileCoords = tile.gridCoords;
        return !placedOnGrid || (Math.Abs(tileCoords.x - gridCoords.x) <= 1 && Math.Abs(tileCoords.y - gridCoords.y) <= 1);
    }

    public void MoveTo(MoveTarget tile)
    {
        if (CanMoveTo(tile))
        {
            placedOnGrid = true;
            gridCoords = tile.gridCoords;

            lastPosition = targetPosition;
            targetPosition = tile.gameObject.transform.position + offset;
            percentToTarget = 0;
            secondsToTarget = Math.Abs((lastPosition - targetPosition).magnitude) / moveSpeed;
        }
        else
        {
            Debug.Log("Can't move there!");
            Debug.Log(gridCoords);
            Debug.Log(tile.gridCoords);
        }
    }
}
