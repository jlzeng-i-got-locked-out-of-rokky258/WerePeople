using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighlightManager : MonoBehaviour
{

    private GameController gameController;
    public SpriteRenderer sprite;
    public TMP_Text hpT, atkT, spdT, defT, nameT;

    private PlayerActions playeractions;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.instance();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerActions playeractions = this.gameObject.GetComponent<PlayerActions>();
        transform.localScale = gameController.selectedUnit == this.gameObject ? new Vector3(1.2f, 1.2f, 1.2f) : new Vector3(1.0f, 1.0f, 1.0f);
       
        sprite.color = gameController.hovered == this.gameObject ? Color.red : Color.white;
        if(gameController.selectedUnit == this.gameObject && nameT != null){
            
            nameT.text = playeractions.unitname;
            spdT.text = "Spd: " + playeractions.spd;
            atkT.text = "Atk: " + playeractions.atk;
            defT.text = "Def: " + playeractions.def;
            hpT.text = "HP: " + playeractions.hp + "/" + playeractions.maxHP;
        }
    }
}
