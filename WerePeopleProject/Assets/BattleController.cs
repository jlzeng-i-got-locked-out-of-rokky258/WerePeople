using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BattleController : MonoBehaviour
{

    public CombatantAnimationParams leftCombat;
    public CombatantAnimationParams rightCombat;
    private int combatTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        Disable();

        GameController.instance().battle = this;
        
    }


    public void Disable()
    {
        combatTime = 1000;
        gameObject.GetComponent<Camera>().enabled = false;
    }

    public void Enable(Sprite sprite1, Sprite sprite2)
    {
        combatTime = 0;
        leftCombat.GetComponent<SpriteRenderer>().sprite = sprite2;
        rightCombat.GetComponent<SpriteRenderer>().sprite = sprite1;
        gameObject.GetComponent<Camera>().enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Enable(leftCombat.GetComponent<SpriteRenderer>().sprite, rightCombat.GetComponent<SpriteRenderer>().sprite);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        combatTime++;

        if (combatTime == 10)
        {
            leftCombat.Attack();
        }

        if (combatTime == 65)
        {
            rightCombat.Attack();
        }

        if (combatTime == 140)
        {
            Disable();
        }
    }
}
