using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform Target;
    [SerializeField]private float SmoothSpeed;
    private GameObject GC;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        GC = GameObject.FindGameObjectWithTag("Clock");
    }

    // Update is called once per frame
    void Update()
    {
        if (GC.GetComponent<GameController>().Colisions() == false)
        {
            Vector3 StartPosition = new Vector3(Target.position.x, Target.position.y + 6.12f, -1f);
            Vector3 SmoothPosition = Vector3.Lerp(transform.position, StartPosition, SmoothSpeed);
            transform.position = SmoothPosition;
        }
        else 
        {
            transform.position = new Vector3(0f, 0f, -1f);
        }
    }
}
