using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    [SerializeField] protected int pointsAwarded;
    [SerializeField] protected float Vitesse;
    [SerializeField] protected Vector2 Direction;
    [SerializeField] LayerMask Masque;
    Int_Event ennemiDetruit;
    protected Rigidbody2D myRigidBody;
    protected SpriteRenderer myRenderer;




    // Start is called before the first frame update
    protected virtual void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        ennemiDetruit = new Int_Event();
        ennemiDetruit.AddListener(Score.Instance.UpdateScore);
        myRenderer = GetComponent<SpriteRenderer>();

    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        if (collision.gameObject.CompareTag ("Player"))
        {
            Debug.Log("Collision avec le player");
            //ennemiDetruit.Invoke(pointsAwarded);
            //Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
            ChangeDirection();

    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(Direction.x * Vitesse, myRigidBody.velocity.y);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Direction, Vector2.down, 0.1f, Masque); //Raycast en bas pour checker si on touche le sol (avec un masque pour ne pas checker les colliders du player). On décale le pt de départ du RayCast en fonction de la variabl direction pour qu'il soit au bout de l'ennemi
        Debug.DrawRay((Vector2)transform.position + Direction, Vector2.down * 0.1f);
        if (hit.collider == null)
            ChangeDirection();
    }
    protected void ChangeDirection()
    {
        myRenderer.flipX = !myRenderer.flipX;//on inverse la variable flipX
        Direction *= Vector2.left;//là aussi on inverse la direction
    }

    protected void OnValidate()
    {
        Vitesse = Mathf.Clamp(Vitesse, 0f, float.MaxValue);//à chaque changement dans l'éditeur la vitesse est comprise entre 0 et le max de float
    }
}
