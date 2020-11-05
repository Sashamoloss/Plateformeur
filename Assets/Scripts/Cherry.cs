using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : Bonus
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider); // ça sert à quoi ça déjà 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
