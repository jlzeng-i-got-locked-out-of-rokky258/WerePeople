using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInitial : MonoBehaviour
{  public GameObject unit, weapon;
    // Start is called before the first frame update
    public Sprite unitSprite, weaponSprite;
    
    public Color wColor;
    void Start()
    {
        unit.GetComponent<SpriteRenderer>().sprite = unitSprite;
        weapon.GetComponent<SpriteRenderer>().sprite = weaponSprite;
        weapon.GetComponent<SpriteRenderer>().color = wColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
