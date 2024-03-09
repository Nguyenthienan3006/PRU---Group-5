using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springboard : MonoBehaviour
{
    public float jumpForce = 15f; // Lực đẩy khi nhảy

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Kiểm tra xem đối tượng va chạm có phải là player không
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>(); // Lấy component Rigidbody2D của player

            if (rb != null)
            {
                // Tạo một vector lực để đẩy player lên
                Vector2 jumpVector = new Vector2(0f, jumpForce);
                rb.velocity = Vector2.zero; // Đặt vận tốc của player về 0 trước khi áp dụng lực
                rb.AddForce(jumpVector, ForceMode2D.Impulse); // Áp dụng lực đẩy lên player
            }
        }
    }
}
