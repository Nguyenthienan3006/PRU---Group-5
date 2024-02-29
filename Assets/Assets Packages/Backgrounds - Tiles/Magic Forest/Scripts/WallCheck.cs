using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    [SerializeField] private float m_jumpForce = 7.5f;
    [SerializeField] private float m_wallJumpSpeed = 4.0f;

    private Rigidbody2D m_body2d;

    private void Start()
    {
        m_body2d = GetComponent<Rigidbody2D>();
    }

    public void DoWallJump(int wallDirection)
    {
        // Perform wall jump
        m_body2d.velocity = new Vector2(wallDirection * m_wallJumpSpeed, m_jumpForce);
    }
}
