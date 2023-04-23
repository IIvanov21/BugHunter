using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerBaseState
{
    private readonly int FallingHash = Animator.StringToHash("Falling");
    private const float CrossFadeDuration = 0.1f;
    public PlayerFallingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Entering Falling");
        stateMachine.Animator.CrossFadeInFixedTime(FallingHash,CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);
        if (stateMachine.Controller.isGrounded)
        {
            stateMachine.SwitchState(new PlayerFreeState(stateMachine,true));
            return;
        }
    }

    public override void Exit()
    {
    }
}
