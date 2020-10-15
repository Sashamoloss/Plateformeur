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
    SpriteRenderer myRenderer;
    private Rigidbody2D myRigidBody;
    private Controles Inputs;
    private float Direction;
    private bool CheckGround; //Indique si on touche le sol ou pas

    // Start is called before the first frame update
    void OnEnable()
    {
        //myRigidBody.AddForce(transform.right * Vitesse);
        Inputs = new Controles();
        Inputs.Enable();
        Inputs.Action_Map.Deplacement.performed += Deplacement;
        Inputs.Action_Map.Deplacement.canceled += DeplacementAnnule;
        Inputs.Action_Map.Saut.performed += Saut;
        //Inputs.Action_Map.Saut.canceled += SautAnnule
    }
    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();        
        PlayerAnimator = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,1.1f, Masque); //Raycast en bas pour checker si on touche le sol (avec un masque pour ne pas checker les colliders du player)
        CheckGround = hit.collider != null; //On met dans Checkground le résultat de la question "est-ce qu'il y a qqch dans le hit.collider ?"
        var ForceDirection = new Vector2(Direction, 0);
        myRigidBody.AddForce(ForceDirection * Vitesse);
        if (myRigidBody.velocity.y < 0) //si le joueur tombe, alors on lance l'animation de chute
            PlayerAnimator.SetTrigger("Fall");
        if (Direction == -1)
            myRenderer.flipX = true;
        if (Direction == 1)
            myRenderer.flipX = false;

        PlayerAnimator.SetBool("CheckGround",CheckGround);//Pour arrêter l'animation de chute si on touche le sol
        //Debug.DrawRay(transform.position, Vector2.down * 1.1f);

    }

    void Deplacement(InputAction.CallbackContext CBC)
    {
        Direction = CBC.ReadValue<float>();
        PlayerAnimator.SetBool("Deplacement", true); //Pour lancer l'animation de déplacement
    }

    void DeplacementAnnule(InputAction.CallbackContext CBC)
    {
        Direction = 0;
        PlayerAnimator.SetBool("Deplacement", false); //Pour arrêter l'animation de déplacement
    }

    void Saut(InputAction.CallbackContext CBC)
    {
        if (CheckGround) //Si on touche le sol, alors on peut sauter
        {
            myRigidBody.AddForce(transform.up * ForceDeSaut, ForceMode2D.Impulse);
            PlayerAnimator.SetTrigger("Jump");
        }
        

    }
}
