using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : Collectable
{

    public Sprite emptyChest;
    public int pesosAmount = 5;
    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            //shows text when you collect pesos from it - collected pesos amount, yello collor, text will be on the chest position, it will move upwards, it will show for 3 secs
            GameManager.instance.ShowText("+ " + pesosAmount + " pesos!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
    
        }    
    }


}
