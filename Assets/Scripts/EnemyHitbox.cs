using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    //Damage
    public int damage = 1;
    public float pushForce = 3;

    protected override void OnCollide(Collider2D coll)
    {
        //Check if u've hit the player
        if(coll.tag == "Fighter"&&coll.name=="Player")
        {
            //Create a new object, before sending it to the player - copy from weapon script
            Damage dmg = new Damage()
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
