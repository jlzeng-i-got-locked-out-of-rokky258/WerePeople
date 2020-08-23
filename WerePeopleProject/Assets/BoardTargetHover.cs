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
        moveIcon.GetComponent<IconBob>().highlighted = gameController.hovered == gameObject;
    }
}
