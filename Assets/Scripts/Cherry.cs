using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : Bonus
{
    protected override void Start()
    {
        base.Start();//pour que ce soit le script parent qui se lance
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider); //pour lancer la fonction OnTriggerEnter2D du script parent
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
