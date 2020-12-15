using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_behavior : MonoBehaviour
{
    [SerializeField] float Vitesse;
    [SerializeField] float ForceDeSaut;
    [SerializeField] LayerMask Masque;
    [SerializeField] float VitesseMax; //Pour ne pas avoir d'accélération
    [SerializeField] float slopeCompensation;
    [SerializeField] [Range(0, 5)] protected float tailleRayCast;
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, tailleRayCast, Masque); //Raycast en bas pour checker si on touche le sol (avec un masque pour ne pas checker les colliders du player)
        CheckGround = hit.collider != null; //On met dans Checkground le résultat de la question "est-ce qu'il y a qqch dans le hit.collider ?"
        Debug.DrawRay(transform.position, Vector2.down * tailleRayCast);
        float verticalDirection;
        var isClimbingLeft = myRenderer.flipX && hit.normal.x > 0; //si on est tourné à gauche et que la normale penche à droite
        var isClimbingRight = !myRenderer.flipX && hit.normal.x < 0; //inversement
        if (isClimbingLeft || isClimbingRight)
            verticalDirection = slopeCompensation;
        else 
            verticalDirection = 0;
        var ForceDirection = new Vector2(Direction, verticalDirection);
        Debug.Log("verticaledirection "+ verticalDirection);
        if (Direction != 0)
            myRigidBody.AddForce(ForceDirection.normalized * Vitesse);
        //if (myRigidBody.velocity.y < - 0.1f) //si le joueur tombe, alors on lance l'animation de chute
        //    PlayerAnimator.SetTrigger("Fall");
        if (Mathf.Abs (myRigidBody.velocity.x) > VitesseMax)//la vélocité en valeur absolue car pê négative
            myRigidBody.velocity = new Vector2 (VitesseMax,myRigidBody.velocity.y);//quand le joueur atteint la vitesse maximum, on bloque l'accélération horizontale de son rigidbody (on ne peut pas assigner rigidbody.velocity.x donc obligée de faire le truc avec tout le vecteur
        PlayerAnimator.SetFloat("VelocityY", myRigidBody.velocity.y);
        PlayerAnimator.SetFloat("VitesseX", Mathf.Abs (myRigidBody.velocity.x));
        PlayerAnimator.SetBool("CheckGround",CheckGround);//Pour arrêter l'animation de chute si on touche le sol
        //Debug.DrawRay(transform.position, Vector2.down * 1.1f);
    }

    void Deplacement(InputAction.CallbackContext CBC)
    {
        Direction = CBC.ReadValue<float>();
        //PlayerAnimator.SetTrigger("Deplacement");
        myRenderer.flipX = Direction == -1; //On met dans flipX le résultat de la comparaison "Direction est-il égal à -1"
        //PlayerAnimator.SetBool("Deplacement", true); //Pour lancer l'animation de déplacement
    }

    void DeplacementAnnule(InputAction.CallbackContext CBC)
    {
        Direction = 0;
        //PlayerAnimator.ResetTrigger("Deplacement");
        //PlayerAnimator.SetBool("Deplacement", false); //Pour arrêter l'animation de déplacement
    }

    void Saut(InputAction.CallbackContext CBC)
    {
        if (CheckGround) //Si on touche le sol, alors on peut sauter
        {
            myRigidBody.AddForce(transform.up * ForceDeSaut, ForceMode2D.Impulse);
            //PlayerAnimator.SetTrigger("Jump");
        }
        

    }
}
