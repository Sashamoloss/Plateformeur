using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    [SerializeField] protected int pointsAwarded;
    [SerializeField] protected float Vitesse;
    //[SerializeField] protected float VitesseMax; //Pour ne pas avoir d'accélération (mais si on en veut pas du tout autant utiliser la variable Vitesse ?)
    [SerializeField] protected Vector2 Direction;
    Int_Event ennemiDetruit;
    protected Rigidbody2D myRigidBody;



    // Start is called before the first frame update
    protected virtual void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        ennemiDetruit = new Int_Event();
        ennemiDetruit.AddListener(Score.Instance.UpdateScore);
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

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigidBody.AddForce(Direction * Vitesse);
        if (myRigidBody.velocity.x > Vitesse)
            myRigidBody.velocity = new Vector2(Vitesse, myRigidBody.velocity.y);//quand l'ennemi atteint la vitesse maximum, on bloque l'accélération horizontale de son rigidbody (on ne peut pas assigner rigidbody.velocity.x donc obligée de faire le truc avec tout le vecteur
    }
}
