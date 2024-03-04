using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private int addX;
    [SerializeField] private int addY;
    [SerializeField] private Transform player;

    private void Update()
    {
        transform.position = new Vector3(player.position.x + addX, player.position.y + addY, transform.position.z);
    }
}
