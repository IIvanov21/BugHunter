using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private CharacterController2D characterController;
    //[SerializeField] private NavMeshAgent agent;

    private float verticalVelocity;
    private Vector2 impact;
    private Vector2 dampingVelocity;
    public Vector2 Movement => impact + Vector2.up * verticalVelocity;
    [SerializeField] private float drag = 0.3f;
    private void Update()
    {
        //Gravity Handler
        if (characterController.wasGrounded && verticalVelocity < 0.0f)
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        impact = Vector2.SmoothDamp(impact, Vector2.zero, ref dampingVelocity, drag);

        if (impact.sqrMagnitude < 0.2f * 0.2f)
        {
            impact = Vector2.zero;
            //if (agent != null) agent.enabled = true;
        }
    }

    public void AddForce(Vector2 force)
    {
        impact += force;
        /*if (agent != null)
        {
            agent.enabled = false;
        }*/

    }

    public void Jump(float jumpForce)
    {
        verticalVelocity += jumpForce;
    }

    internal void Reset()
    {
        impact = Vector2.zero;
        verticalVelocity = 0.0f;
    }
}
