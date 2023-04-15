using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerIdleState : PlayerBaseState
{
    private readonly int IdleHash = Animator.StringToHash("Idle");
    private const float CrossFadeDuration = 0.1f;

    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine){    }

    public override void Enter()
    {
        Debug.Log("Entering Idle state!");
        stateMachine.Animator.CrossFadeInFixedTime(IdleHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        /*if(stateMachine.InputReader.MovementValue.x>0 || stateMachine.InputReader.MovementValue.x<0)
        {
            stateMachine.SwitchState(new PlayerMoveState(stateMachine));
            return;
        }*/
        Debug.Log("Input: ");
        Move(stateMachine.Speed * stateMachine.InputReader.MovementValue, deltaTime);

    }

    public override void Exit()
    {

    }


   
}
