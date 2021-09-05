using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Experience reward
    public int xpValue = 1;

    //Logic
    public float triggerLength = 1; //If u come within 1m enemy starts chasing you
    public float chaseLength = 5; //If you exite 5m radius he stops chasing you
    private bool chasing;
    private bool collidingWithPlayer; //Way to know if enemy is currently colliding with the player - stops moving
    private Transform playerTransform;
    private Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start(); //We still want to be using what's in the base
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>(); //Without transform.GetChild(0) we would get che boxCollider, but we want to get the HITBOX

    }

    private void FixedUpdate()
    {
        //Is the player in range?
        if(Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)//Distance from the players current position, and enemy starting position against chase length
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
                chasing = true;

            if (chasing)
            {
                if (collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
                    
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);//Returns to where he spawned
            }
            
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        //Check for overlaps
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if(hits[i].tag == "Fighter" && hits[i].name == "Player" ) //If colliding with other fighter and if that fighter is player
            {
                collidingWithPlayer = true;
            }

            //Array isn't cleaned up every time, we do it ourself
            hits[i] = null;
        }


    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.experience += xpValue;
        GameManager.instance.ShowText("+ " + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }
}
