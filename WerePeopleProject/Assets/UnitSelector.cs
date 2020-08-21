using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    public GameController gameController;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.transform.gameObject;

                PlayerActions actions = obj.GetComponent<PlayerActions>()
                if (actions != null && actions.IsActive())
                {
                    gameController.selectedUnit = obj;
                }
            }
        }
        
    }
}
