using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEditor.ShaderGraph;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MovementValue { get; private set; }
    public bool IsJumping { get; private set; } = false;
    public bool IsCrouching { get; private set; } = false;

    private Controls controls;

    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)IsJumping = true;
        if(context.canceled)IsJumping=false;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
        Debug.Log(MovementValue);

    }

    public void OnTarget(InputAction.CallbackContext context)
    {
    }
}
