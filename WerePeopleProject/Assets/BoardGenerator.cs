using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{

    MoveTarget[,] board;
    public GameObject boardMoveTarget;
    private int width, height;
    // Start is called before the first frame update
    void Start()
    {
        GameController.instance().board = this;
        MakeBoard(8, 8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeBoard(int _width, int _height)
    {
        width = _width; height = _height;
        board = new MoveTarget[width, height];
        for (int i = 0; i < width; i ++)
        {
            for (int j = 0; j < height; j ++)
            {
                GameObject newTarget = Instantiate(boardMoveTarget, transform.position + new Vector3(i, 0, j), Quaternion.identity);
                MoveTarget moveTarget = newTarget.GetComponent<MoveTarget>();
                moveTarget.gridCoords = new Vector2(i, j);
                board[i, j] = moveTarget;
            }
        }
    }
    
    public void highlightMoveable(PlayerActions active)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                board[i, j].moveHighlight = active != null && active.CanMoveTo(board[i, j]);
            }
        }
    }
}
