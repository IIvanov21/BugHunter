using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    private readonly int IdleHash = Animator.StringToHash("Idle");
    private const float CrossFadeDuration = 0.1f;

    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine){    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(IdleHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        
        Move(stateMachine.Speed * stateMachine.InputReader.MovementValue, deltaTime);
        Move(deltaTime);

        if (stateMachine.InputReader.IsJumping)
        {
            stateMachine.Controller.m_JumpTimer = 0.3f;
        }

    }

    public override void Exit()
    {

    }


   
}
