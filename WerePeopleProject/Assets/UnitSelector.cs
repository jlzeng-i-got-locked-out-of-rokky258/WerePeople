using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    private GameController gameController;
    
    void Start()
    {
        gameController = GameController.instance();
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            GameObject obj = hit.transform.gameObject;
            gameController.hovered = obj;

            PlayerActions actions = obj.GetComponent<PlayerActions>();
            MoveTarget tile = obj.GetComponent<MoveTarget>();

            if (Input.GetMouseButtonDown(0))
            {
                
                if (actions != null && actions.IsActive()) // Clicked an active player unit
                {
                    gameController.selectedUnit = obj;
                } else if (tile != null && tile.IsPassable())
                {
                    gameController.MoveUnitTo(tile);
                    gameController.selectedUnit = null;
                } else
                {
                    gameController.selectedUnit = null;
                }
            }
        }
    }
}
