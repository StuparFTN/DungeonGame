using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable //we can overwrite onCollide function and know what the weapon is colliding with
{
    //Damage structure
    public int damagePoint = 1;
    public float pushForce = 2f; //Pushback on hit

    //Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer; //Just so we can change weapon sprite image

    //Swing
    private float cooldown = 0.5f; //Can swing every 0.5 secs
    private float lastSwing; //To know when did we last swing


    protected override void Start()
    {
        base.Start(); //we need to asign box collider and call onCollide
        spriteRenderer = GetComponent<SpriteRenderer>(); //so that we can change weapon sprite when it levels up

    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    //We need to make sure to tag everything that weapon can hit - everything that has HP
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
                return;

            //Create a new damage object, then we'll send it to the fighter we've hit
            Damage dmg = new Damage()
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);
            
            
                Debug.Log(coll.name);
            
        }
    }
    private void Swing()
    {
        Debug.Log("Swing");
    }
}
