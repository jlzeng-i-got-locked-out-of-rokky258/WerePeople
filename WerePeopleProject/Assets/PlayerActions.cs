using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    public int movementLength, attackRange, atk, spd, hp, def, maxHP;
    public string unitname;
    // Variables related to grid positioning.
    public MoveTarget location;

    private float time = 0;

    // Variables related to combat stats.
    public int remainingMoves;
    public bool hasAttacked;
    

    // Start is called before the first frame update
    void Awake()
    {
        offset = new Vector3(0f, 1f, 0f);
        targetPosition = this.gameObject.transform.position;
        lastPosition = this.gameObject.transform.position;
        Refresh();
    }

    public void Refresh()
    {
        remainingMoves = movementLength;
        hasAttacked = false;
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
        return remainingMoves > 0 || !hasAttacked;
    }


    // Should be overridden for children of PlayerActions
    // This default method provides a single tile of movement.
    // CanMoveTo is also used to figure out which grid tiles to highlight for potential movement.
    public bool CanMoveTo(MoveTarget tile)
    {
        if (tile == location) return false;
        if (location == null) return tile.IsPassable();
        //return tile.IsPassable() && ((Math.Abs(tileCoords.x - gridCoords.x) <= 1 && Math.Abs(tileCoords.y - gridCoords.y) <= 1 && Math.Abs(tileCoords.y - gridCoords.y) + Math.Abs(tileCoords.x - gridCoords.x) != 0));
        return tile.IsPassable() && Distance(tile) <= remainingMoves;
    }
      public bool CanAttack(MoveTarget tile)
    {
        if (tile == location) return false;
        if (location == null) return false;
        //return tile.IsPassable() && ((Math.Abs(tileCoords.x - gridCoords.x) <= 1 && Math.Abs(tileCoords.y - gridCoords.y) <= 1 && Math.Abs(tileCoords.y - gridCoords.y) + Math.Abs(tileCoords.x - gridCoords.x) != 0));
        return !tile.IsPassable() && Distance(tile) <= attackRange;
    }

    public int Distance(MoveTarget tile)
    {

        if (location == null || tile == location) return 0;
        Vector2 tileCoords = tile.gridCoords;
        Vector2 gridCoords = location.gridCoords;
        return (int) Math.Round(Math.Abs(tileCoords.y - gridCoords.y) + Math.Abs(tileCoords.x - gridCoords.x));
    }

    public void JumpTo(MoveTarget tile)
    {
        if (location != null)
        {
            location.occupant = null;
        }
        location = tile;
        location.occupant = this.gameObject;
        Debug.Log(offset);
        
        targetPosition = tile.gameObject.transform.position + offset;
        lastPosition = targetPosition;
        percentToTarget = 1;
        secondsToTarget = 0;

        gameObject.transform.position = targetPosition;
    }
    public void MoveTo(MoveTarget tile)
    {
        if (CanMoveTo(tile))
        {
            remainingMoves -= Distance(tile);
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

    public bool Attack(GameObject enemy)
    {
        PlayerActions actions = enemy.GetComponent<PlayerActions>();
        if (CanAttack(actions.location))
        {
            hasAttacked = true;
            Debug.Log("It is marginally effective!");
            return true;
        }
        else
        {
            Debug.Log("Can't attack that!");
            return false;
        }
    }
}
