using Unity.Mathematics;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int dir = 0;
    private float movespd = 15;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, dir, 0) * movespd * Time.deltaTime);
        if (math.abs(transform.position.y) > 10) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemy = collision.gameObject;
        if (enemy.tag == "enemy" && dir == 1 || enemy.tag == "bullet")
        {
            Destroy(enemy);
            Destroy(gameObject);
        }
    }
}
