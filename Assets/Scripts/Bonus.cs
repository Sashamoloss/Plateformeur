using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] protected int pointsAwarded;
    Int_Event bonusAttrape;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        bonusAttrape = new Int_Event();
        bonusAttrape.AddListener(Score.Instance.UpdateScore); //Pour mettre le script Score dans Bonus
    }

    protected virtual void OnTriggerEnter2D (Collider2D collider)
    {
        bonusAttrape.Invoke(pointsAwarded);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
