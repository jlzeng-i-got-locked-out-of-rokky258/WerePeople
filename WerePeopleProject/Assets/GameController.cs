using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject selectedUnit;
    public BoardGenerator board;
    public GameObject hovered;
    static GameObject _instance;
    public BattleController battle;

    public void Update()
    {
        board.highlightMoveable(selectedUnit?.GetComponent<PlayerActions>());
    }



    public static GameController instance()
    {
        if (_instance == null)
        {
            _instance = new GameObject("Game Controller");
            _instance.AddComponent<GameController>();
        }
        return _instance.GetComponent<GameController>();
    }

    public void MoveUnitTo(MoveTarget tile)
    {
        selectedUnit?.GetComponent<PlayerActions>().MoveTo(tile);
    }

    public void AttackUnit(GameObject unitObject)
    {
        if (selectedUnit == null) return;
        if (selectedUnit.GetComponent<PlayerActions>().Attack(unitObject))
        {
            battle.Enable();
        }
    }
}
