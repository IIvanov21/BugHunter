using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerJumpState : PlayerBaseState
{
    private readonly int JumpHash = Animator.StringToHash("Jump");
    private const float CrossFadeDuration = 0.1f;
    private Vector2 momentum;
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }
    public override void Enter()
    {
        Debug.Log("Entering Jump");
        stateMachine.Animator.CrossFadeInFixedTime(JumpHash,CrossFadeDuration);
        stateMachine.Controller.m_JumpTimer = 0.3f;

        momentum = stateMachine.Controller.velocity;
        momentum.y = 0.0f;
    }
    public override void Tick(float deltaTime)
    {
        Move(momentum,deltaTime);
        if (stateMachine.Controller.CheckVelocity() )
        {
            stateMachine.SwitchState(new PlayerFallingState(stateMachine));
            return;
        }
        
    }

    public override void Exit()
    {

    }
}
