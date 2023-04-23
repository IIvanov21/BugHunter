using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private Attack attack;

    private const float CrossFadeDuration = 0.1f;
    
    private float previousFrameTime;
    private bool alreadyAppliedForce = false;
    public PlayerAttackState(PlayerStateMachine stateMachine,int attackIndex) : base(stateMachine)
    {
        attack = stateMachine.Attacks[attackIndex];

    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, CrossFadeDuration);
        //stateMachine.WeaponDamage.SetAttack(attack.Damage, attack.Knockback);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        float normalisedTime = GetNormalisedTime(stateMachine.Animator, "Attack");
        if(normalisedTime >= previousFrameTime && normalisedTime<1.0f) 
        {
            if(normalisedTime >=attack.ForceTime)
            {
                TryApplyForce();
            }
            if(stateMachine.InputReader.IsAttacking)
            {
                TryComboAttack(normalisedTime);
            }
        }
        else 
        {
            stateMachine.SwitchState(new PlayerFreeState(stateMachine,true));
        }

        previousFrameTime = normalisedTime;
    }

    private void TryComboAttack(float normalisedTime)
    {
        
        if (attack.ComboStateIndex == -1) return;
        if (normalisedTime < attack.ComboAttackTime) return;

        stateMachine.SwitchState(new PlayerAttackState(stateMachine,attack.ComboStateIndex));
    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        if(stateMachine.transform.localScale.x<0)stateMachine.ForceReceiver.AddForce(-stateMachine.transform.right * attack.Force);
        else stateMachine.ForceReceiver.AddForce(stateMachine.transform.right * attack.Force);
        alreadyAppliedForce = true;
    }

    public override void Exit()
    {
        stateMachine.WeaponDamage?.gameObject?.SetActive(false);
    }

}
