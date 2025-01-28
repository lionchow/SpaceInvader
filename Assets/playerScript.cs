using Unity.Mathematics;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public int movespd;
    [SerializeField] private bulletSpawnerScript Spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        if (Input.GetKey(KeyCode.A)) { transform.Translate(Vector2.left * movespd * Time.deltaTime); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(Vector2.right * movespd * Time.deltaTime); }
        if (transform.position.x < -15.5 || transform.position.x > 15.5) { transform.position = new Vector3((float)(math.sign(transform.position.x) * 15.5), -8, 1); }

        //shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawner.SpawnBullet(1, transform.position);
        }
    }
}
