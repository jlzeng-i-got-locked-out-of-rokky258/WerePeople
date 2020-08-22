using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTargetHover : MonoBehaviour
{

    private GameController gameController;
    public GameObject moveIcon;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.instance();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.hovered == gameObject)
        {
            moveIcon.GetComponent<SpriteRenderer>().color = Color.blue;
        } else
        {
            moveIcon.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
}
