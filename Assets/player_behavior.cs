using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_behavior : MonoBehaviour
{
    [SerializeField] float Vitesse = 0;
    [SerializeField] float ForceDeSaut = 0;
    [SerializeField] LayerMask Masque;
    Animator PlayerAnimator;
    private Rigidbody2D myRigidBody;
    private Controles Inputs;
    private float Direction;


    // Start is called before the first frame update
    void OnEnable()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.AddForce(transform.right * Vitesse);
        Inputs = new Controles();
        Inputs.Enable();
        Inputs.Action_Map.Deplacement.performed += Deplacement;
        Inputs.Action_Map.Deplacement.canceled += DeplacementAnnule;
        Inputs.Action_Map.Saut.performed += Saut;
        var PlayerAnimator = GetComponent<Animator>();
        //Inputs.Action_Map.Saut.canceled += SautAnnule

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,1.1f, Masque); //Raycast en bas pour checker si on touche le sol (avec un masque pour ne pas checker les colliders du player)
        var ForceDirection = new Vector2(Direction, 0);
        myRigidBody.AddForce(ForceDirection * Vitesse);
    }

    void Deplacement(InputAction.CallbackContext CBC)
    {
        Direction = CBC.ReadValue<float>();
    }

    void DeplacementAnnule(InputAction.CallbackContext CBC)
    {
        Direction = 0;
    }

    void Saut(InputAction.CallbackContext CBC)
    {
        //if (myRigidBody.GetContacts())
        myRigidBody.AddForce(transform.up * ForceDeSaut, ForceMode2D.Impulse);
        //PlayerAnimator.SetTrigger("Jump");
        

    }
}
