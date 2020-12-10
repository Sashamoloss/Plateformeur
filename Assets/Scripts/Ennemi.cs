using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    [SerializeField] protected int pointsAwarded;
    [SerializeField] [Range(0,float.MaxValue)] protected float Vitesse;
    [SerializeField] [Range(0, 5)] protected float tailleRayCastSide;
    [SerializeField] [Range(0, 5)] protected float tailleRayCastDown;
    [SerializeField] float slopeCompensation;
    protected float verticalDirection = 0;
    //[SerializeField] protected Vector2 DecalageRayCast;
    [SerializeField] LayerMask Masque;
    Int_Event ennemiDetruit;
    protected Rigidbody2D myRigidBody;
    protected SpriteRenderer myRenderer;
    protected Vector2 Direction;



    // Start is called before the first frame update
    protected virtual void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        ennemiDetruit = new Int_Event();
        ennemiDetruit.AddListener(Score.Instance.UpdateScore);
        myRenderer = GetComponent<SpriteRenderer>();
        Direction = Vector2.left;

    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("Player"))
        {
            //ennemiDetruit.Invoke(pointsAwarded);
            //Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
            ChangeDirection();

    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(Direction.x * Vitesse, myRigidBody.velocity.y + verticalDirection);//pour empêcher l'accélération
        RaycastHit2D hitDown = Physics2D.Raycast((Vector2)transform.position + Direction + Vector2.up, Vector2.down, tailleRayCastDown, Masque);
        //Raycast en bas pour checker si on touche le sol (avec un masque pour ne pas checker les colliders du player). 
        //On décale le pt de départ du RayCast en fonction de la variable direction pour qu'il soit au bout de l'ennemi
        //+ une variable sérialisée pour qu'il soit toujours au bout quand il change de direction (mais pas trop loin)
        RaycastHit2D hitSide = Physics2D.Raycast((Vector2)myRenderer.bounds.center, Direction, tailleRayCastSide, Masque);
        Debug.DrawRay((Vector2)myRenderer.bounds.center, Direction * tailleRayCastSide);
        Debug.DrawRay((Vector2)transform.position + Direction + Vector2.up, Vector2.down * tailleRayCastDown);
        if (hitDown.collider == null || hitSide.collider != null)
            ChangeDirection();
        var isClimbingLeft = myRenderer.flipX && hitDown.normal.x > 0; //si on est tourné à gauche et que la normale penche à droite
        var isClimbingRight = !myRenderer.flipX && hitDown.normal.x < 0; //inversement
        if (isClimbingLeft || isClimbingRight)
            verticalDirection = slopeCompensation;
        else
            verticalDirection = 0;
    }
    protected void ChangeDirection()
    {
        myRenderer.flipX = !myRenderer.flipX;//on inverse la variable flipX
        Direction *= Vector2.left;//là aussi on inverse la direction
    }

    protected void OnValidate()
    {
        //DecalageRayCast.x = Mathf.Clamp(DecalageRayCast.x, 0f, 0.5f);//Le x du décalage du raycast sera compris entre 0 et 0.5
    }
}
