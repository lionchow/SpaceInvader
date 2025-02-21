using Unity.Mathematics;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int dir = 0;
    private float movespd = 15;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movespd * Time.deltaTime * new Vector3(0, dir, 0));
        if (math.abs(transform.position.y) > 10) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemy = collision.gameObject;
        if ((enemy.CompareTag("enemy1") || enemy.CompareTag("enemy2")) && (dir == 1 || enemy.CompareTag("bullet")))
        {
            if (enemy.CompareTag("enemy1")||enemy.CompareTag("enemy2"))
            {
                enemySpawnerScript.loopSpd += 0.05f;
            }
            Destroy(enemy);
            Destroy(gameObject);
        }
        else if (enemy.CompareTag("Player") && dir == -1)
        {
            Debug.Log("Game over");
        }
    }
}
