using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeState : PlayerBaseState
{
    private readonly int LocomotionBlendTreeHash = Animator.StringToHash("Locomotion");
    private readonly int LocomotionSpeedHash = Animator.StringToHash("LocomotionSpeed");
    private const float AnimationDamp = 0.1f;
    private const float CrossFadeDuration = 0.1f;
    private bool shouldFade = false;

    public PlayerFreeState(PlayerStateMachine stateMachine, bool shouldFade=false) : base(stateMachine)
    {
        this.shouldFade = shouldFade;
    }

    public override void Enter()
    {
        if(shouldFade)stateMachine.Animator.CrossFadeInFixedTime(LocomotionBlendTreeHash, CrossFadeDuration);
        else
        {
            stateMachine.Animator.Play(LocomotionBlendTreeHash);
            stateMachine.Animator.SetFloat(LocomotionSpeedHash, 0);
        }
    }

    public override void Tick(float deltaTime)
    {
        if(stateMachine.InputReader.IsAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackState(stateMachine, 0));
            return;
        }
        
        if (stateMachine.InputReader.IsJumping)
        {
            stateMachine.SwitchState(new PlayerJumpState(stateMachine));
            return;
        }
        //Base functionality for moving and while being Idle
        
        Move(stateMachine.Speed * stateMachine.InputReader.MovementValue, deltaTime);
      

        

        UpdateAnimationMovement();
    }

    public override void Exit()
    {

    }

    private void UpdateAnimationMovement()
    {
        stateMachine.Animator.SetFloat(LocomotionSpeedHash, Mathf.Abs(stateMachine.InputReader.MovementValue.x));
    }

   
}
