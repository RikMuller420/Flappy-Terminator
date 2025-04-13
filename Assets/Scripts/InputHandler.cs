using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const KeyCode JumpKeyCode = KeyCode.Space;
    private const KeyCode ShootKeyCode = KeyCode.Q;

    public event Action JumpPressed;
    public event Action ShootPressed;

    void Update()
    {
        if (Input.GetKeyDown(JumpKeyCode))
        {
            JumpPressed?.Invoke();
        }

        if (Input.GetKeyDown(ShootKeyCode))
        {
            ShootPressed?.Invoke();
        }
    }
}
