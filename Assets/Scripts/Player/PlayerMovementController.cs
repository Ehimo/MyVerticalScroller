using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var playerInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = Vector2.right * playerInput * moveSpeed * Time.fixedDeltaTime;
    }

}
