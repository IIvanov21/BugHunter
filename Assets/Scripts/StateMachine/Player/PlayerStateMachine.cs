using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController2D Controller { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Attack [] Attacks { get; private set; }
    [field: SerializeField] public WeaponDamage WeaponDamage { get; private set; }



    [field: SerializeField] public float Speed { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        SwitchState(new PlayerFreeState(this));
    }
}
