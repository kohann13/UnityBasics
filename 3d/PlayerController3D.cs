using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    //components
    private Rigidbody Rb;

    //move
    [SerializeField] private float Speed;
    [SerializeField] private Transform Orientation;
    private float Horizontal;
    private float Vertical;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    private void Move()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        Vector3 Direction = Orientation.forward * Vertical + Orientation.right * Horizontal;

        Rb.velocity = Direction.normalized * Speed;
    }

}
