using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vines : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isClimbing;
    public float climbSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Kiểm tra input và di chuyển player nếu đang leo dây
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical");
            // Áp dụng lực để leo dây
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra va chạm với dây
        if (other.CompareTag("Vines"))
        {
            isClimbing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Kiểm tra khi rời khỏi dây
        if (other.CompareTag("Vines"))
        {
            isClimbing = false;
            rb.velocity = Vector2.zero; // Dừng di chuyển khi rời khỏi dây
        }
    }
}
