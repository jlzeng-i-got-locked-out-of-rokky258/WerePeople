﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{

    public Vector2 gridCoords;
    public bool moveHighlight;
    public GameObject moveHighlightObject;
    public GameObject occupant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveHighlightObject.GetComponent<SpriteRenderer>().enabled = moveHighlight;
    }


    public bool IsPassable()
    {
        return occupant == null;
    }
}
