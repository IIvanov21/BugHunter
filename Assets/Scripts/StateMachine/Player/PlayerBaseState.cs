using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;   
    }

    protected void Move(Vector2 motion, float deltaTime)
    {
        stateMachine.Controller.Move(motion.x + stateMachine.ForceReceiver.Movement.x * deltaTime,true,true);
    }

    protected void Move(float deltaTime)
    {
        stateMachine.Controller.Move(Vector2.zero.x + stateMachine.ForceReceiver.Movement.x * deltaTime,true,true);
    }
}
