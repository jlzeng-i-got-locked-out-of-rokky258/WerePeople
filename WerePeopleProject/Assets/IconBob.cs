using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconBob : MonoBehaviour
{

    private Vector3 startPos;
    private float time;
    public float bobAmount = 0.1f;
    public float bobTime = 1f;
    public bool highlighted = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.position = startPos + new Vector3(0, (float) Math.Sin(time / bobTime) * bobAmount, 0);
        transform.localScale = highlighted ? new Vector3(0.8f, 0.8f, 0.8f) : new Vector3(0.5f, 0.5f, 0.5f);
    }
}
