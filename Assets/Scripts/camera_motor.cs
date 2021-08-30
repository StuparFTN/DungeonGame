using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_motor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f; //how much can player go x before camera moves
    public float boundY = 0.05f; //same for y

    private void LateUpdate() //we need to move camera AFTER player moves
    {
        Vector3 delta = Vector3.zero;

        //this is to check if we're inside the bounds on the x axis
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;

            }
        }

        //this is to check if we're inside the bounds on the y axis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;

            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    
    }
}
