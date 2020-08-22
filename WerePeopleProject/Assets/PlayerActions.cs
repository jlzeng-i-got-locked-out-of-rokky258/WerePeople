using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
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
    public float moveSpeed = 0.5f;
    private float secondsToTarget = 1;

    public BillboardFace sprite;

    public int movementLength, attackRange;

    // Variables related to grid positioning.
    private MoveTarget location;

    private float time = 0;

    private bool hasMoved, hasAttacked = false;
    
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
        sprite.wiggle = (float) Math.Sin(time) * 5f;
        //Debug.Log(secondsToTarget);
        percentToTarget = (float) Math.Min(percentToTarget + (1f / secondsToTarget) * Time.deltaTime, 1);

        time += Time.deltaTime * 40f *  (float) (percentToTarget < 0.99 ? 1 : 0.05);
    }

    // Whether the unit can be activated.
    public bool IsActive()
    {
        return !hasMoved || !hasAttacked;
    }


    // Should be overridden for children of PlayerActions
    // This default method provides a single tile of movement.
    // CanMoveTo is also used to figure out which grid tiles to highlight for potential movement.
    public bool CanMoveTo(MoveTarget tile)
    {
        if (location == null) return tile.IsPassable();
        Vector2 tileCoords = tile.gridCoords;
        Vector2 gridCoords = location.gridCoords;
        //return tile.IsPassable() && ((Math.Abs(tileCoords.x - gridCoords.x) <= 1 && Math.Abs(tileCoords.y - gridCoords.y) <= 1 && Math.Abs(tileCoords.y - gridCoords.y) + Math.Abs(tileCoords.x - gridCoords.x) != 0));
        return tile.IsPassable() && ((Math.Abs(tileCoords.y - gridCoords.y) + Math.Abs(tileCoords.x - gridCoords.x) <= movementLength));
    }
      public bool CanAttack(MoveTarget tile)
    {
        Vector2 tileCoords = tile.gridCoords;
        Vector2 gridCoords = location.gridCoords;
        //return tile.IsPassable() && ((Math.Abs(tileCoords.x - gridCoords.x) <= 1 && Math.Abs(tileCoords.y - gridCoords.y) <= 1 && Math.Abs(tileCoords.y - gridCoords.y) + Math.Abs(tileCoords.x - gridCoords.x) != 0));
        return !tile.IsPassable() && ((Math.Abs(tileCoords.y - gridCoords.y) + Math.Abs(tileCoords.x - gridCoords.x) = attackRange));
    }
    public void MoveTo(MoveTarget tile)
    {
        if (CanMoveTo(tile) && !hasMoved)
        {
            if (location != null)
            {
                location.occupant = null;
            }
            location = tile;
            location.occupant = this.gameObject;

            lastPosition = targetPosition;
            targetPosition = tile.gameObject.transform.position + offset;
            percentToTarget = 0;
            secondsToTarget = Math.Abs((lastPosition - targetPosition).magnitude) / moveSpeed;
        }
        else
        {
            Debug.Log("Can't move there!");
            Debug.Log(location.gridCoords);
            Debug.Log(tile.gridCoords);
        }
    }
}
