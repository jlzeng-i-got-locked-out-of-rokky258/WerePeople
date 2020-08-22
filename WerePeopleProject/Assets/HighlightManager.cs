﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{

    private GameController gameController;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.instance();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = gameController.selectedUnit == this.gameObject ? new Vector3(1.2f, 1.2f, 1.2f) : new Vector3(1.0f, 1.0f, 1.0f);
       
        sprite.color = gameController.hovered == this.gameObject ? Color.red : Color.white;
    }
}
