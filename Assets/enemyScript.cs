using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public int coloumns = 0;
    public bool checkcollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.8f), Vector2.down, 1.5f);
        if (hit)
        {
            GameObject e = hit.collider.gameObject;
            if (e.CompareTag("enemy1"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
}
