using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public GameObject collapsedBridge; // GameObject của cây cầu bị sập
    public float collapseSpeed = 5f; // Tốc độ sập của cây cầu
    public float destroyDelay = 2f; // Thời gian chờ trước khi cây cầu bị phá hủy

    private bool isPlayerPassed = false;
    private bool isCollapsedBridgeMoved = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Kiểm tra nếu player đi qua
        {
            isPlayerPassed = true;
            CollapseBridge();
        }
    }

    private void CollapseBridge()
    {
        if (isPlayerPassed)
        {
            // Ẩn cây cầu gốc
            gameObject.SetActive(false);

            // Hiện cây cầu đã sập
            collapsedBridge.SetActive(true);

            // Di chuyển cây cầu đã sập xuống dưới
            collapsedBridge.transform.Translate(Vector2.down * collapseSpeed * Time.deltaTime);

            // Kiểm tra nếu cây cầu đã di chuyển xuống đủ xa
            if (!isCollapsedBridgeMoved && collapsedBridge.transform.position.y < -10f)
            {
                isCollapsedBridgeMoved = true;
                Invoke("DestroyBridge", destroyDelay); // Gọi hàm DestroyBridge sau một khoảng thời gian destroyDelay giây
            }
        }
    }

    private void DestroyBridge()
    {
        Destroy(collapsedBridge); // Phá hủy cây cầu đã sập
    }
}
