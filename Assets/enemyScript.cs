using Unity.Mathematics;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject[] Spawner;

    private float swingMagnitude = 2;
    private float timer = 0;
    private int shootingInterval = UnityEngine.Random.Range(1, 4);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawner = GameObject.FindGameObjectsWithTag("bulletSpawner");
        

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(new Vector2(math.sin(timer), 0) * swingMagnitude * Time.deltaTime); 

        if (timer%shootingInterval == 0) 
        {
        }
    }
}
