using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerBaseState
{
    void Enter();
    void Tick(float deltaTime);
    void Exit();
}

public abstract class PlayerBaseState : State, IPlayerBaseState
{
    protected PlayerStateMachine stateMachine;

    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;   
    }

    protected void Move(Vector2 motion, float deltaTime)
    {
        stateMachine.Controller.Move(motion.x + stateMachine.ForceReceiver.Movement.x * deltaTime,stateMachine.InputReader.IsCrouching,stateMachine.InputReader.IsJumping);
    }

    protected void Move(float deltaTime)
    {
        stateMachine.Controller.Move(Vector2.zero.x + stateMachine.ForceReceiver.Movement.x * deltaTime, stateMachine.InputReader.IsCrouching, stateMachine.InputReader.IsJumping);
    }
}
