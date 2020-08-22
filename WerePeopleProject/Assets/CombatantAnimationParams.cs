using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class CombatantAnimationParams : MonoBehaviour
{

    public float horizontalOffset;
    public float verticalOffset;
    public float shakeAmount;
    public float orientation;
    public Vector3 offset;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = offset + new Vector3(horizontalOffset * orientation + Random.Range(-shakeAmount, shakeAmount) / 100, verticalOffset + Random.Range(-shakeAmount, shakeAmount) / 100, 1);
        
    }

    public void Attack()
    {
        anim.SetTrigger(Animator.StringToHash("BasicAttack"));
    }
}
