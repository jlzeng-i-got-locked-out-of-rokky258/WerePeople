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

    public void Enable()
    {
        combatTime = 0;
        gameObject.GetComponent<Camera>().enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Enable();
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
