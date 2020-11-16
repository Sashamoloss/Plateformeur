using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    [SerializeField] protected int pointsAwarded;
    Int_Event ennemiDetruit;

    // Start is called before the first frame update
    protected virtual void Start()
    {
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
    void Update()
    {
        
    }
}
