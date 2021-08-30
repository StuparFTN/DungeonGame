
using UnityEngine;
using UnityEngine.SceneManagement;



public class Portal : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player");
        {
            //teleport the player 

            GameManager.instance.SaveState();
            SceneManager.LoadScene("Dungeon1", LoadSceneMode.Single);         
        }
    }
}
