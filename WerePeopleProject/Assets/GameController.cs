using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject selectedUnit;
    static GameObject _instance;

    public static GameController instance()
    {
        if (_instance == null)
        {
            _instance = new GameObject("Game Controller");
            _instance.AddComponent<GameController>();
        }
        return _instance.GetComponent<GameController>();
    }
}
