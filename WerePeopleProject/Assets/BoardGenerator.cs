using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{

    MoveTarget[,] board;
    public GameObject boardMoveTarget;
    // Start is called before the first frame update
    void Start()
    {
        MakeBoard(8, 8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeBoard(int width, int height)
    {
        board = new MoveTarget[width, height];
        for (int i = 0; i < width; i ++)
        {
            for (int j = 0; j < height; j ++)
            {
                GameObject newTarget = Instantiate(boardMoveTarget, transform.position + new Vector3(i, 0, j), Quaternion.identity);
                board[i, j] = newTarget.GetComponent<MoveTarget>();
            }
        }
    }
}
