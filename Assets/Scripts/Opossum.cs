using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Ennemi
{
    protected override void Start()
    {
        base.Start(); //pour que ce soit le script parent qui se lance
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision); //pour lancer la fonction OnTriggerEnter2D du script parent
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
