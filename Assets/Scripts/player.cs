using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : Mover
{
    private void FixedUpdate()
    {
        //returns -1 if holding A, 0 if not holding any, 1 if holding D
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));
    }
}
