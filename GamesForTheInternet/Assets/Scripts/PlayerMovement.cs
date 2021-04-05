using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D m_Controller;
    public Animator m_Animator;
    float m_HorizontalMove = 0.0f;
    public float m_RunSpeed = 50.0f;
    bool m_Jump = false; 
    bool m_Crouch = false;

   
    private void Start()
    {
        m_Animator.SetInteger("PlayerChoice", DBManager.m_PlayerChoice);
    }
    // Update is called once per frame
    void Update()
    {

        m_HorizontalMove = Input.GetAxisRaw("Horizontal")*m_RunSpeed;
        m_Animator.SetFloat("PlayerSpeed", Mathf.Abs(m_HorizontalMove * Time.fixedDeltaTime));//Make Speed value always positive

        if (Input.GetButtonDown("Jump"))
        {
            m_Jump = true;
            m_Animator.SetBool("IsJumping", m_Jump);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            m_Animator.SetBool("AttackOn", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            m_Animator.SetBool("AttackOn", false);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            m_Crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            m_Crouch = false;
        }

       
    }
    public void OnLanding()
    {
        m_Jump = false;
       m_Animator.SetBool("IsJumping", m_Jump); 
    }
    public void OnCrouching(bool inCrouching)
    {
        m_Animator.SetBool("IsCrouching", inCrouching);
    }
    void FixedUpdate()
    {
        //Move character here for smoother animation and control
        m_Controller.Move(m_HorizontalMove * Time.fixedDeltaTime, m_Crouch, m_Jump);
        m_Jump = false;

    }
}
