using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player; // Kéo và thả Player vào đây trong Inspector
    public Vector3 offset; // Khoảng cách tương đối giữa Player và Minimap Camera

    void LateUpdate()
    {
        // Kiểm tra xem player có tồn tại không
        if (player != null)
        {
            // Lấy vị trí của player và cộng thêm offset
            Vector3 newPosition = player.position + offset;
            newPosition.z = transform.position.z; // Giữ nguyên vị trí z của minimap camera

            // Cập nhật vị trí của minimap camera
            transform.position = newPosition;
        }
    }
}
