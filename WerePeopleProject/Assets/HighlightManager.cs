using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{

    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.instance();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.selectedUnit == this.gameObject)
        {
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        } else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
