using Unity.Mathematics;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private float shootinginterval = 0;
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
        if (math.abs(transform.position.x) > 8.2) { transform.position = new Vector3((float)(math.sign(transform.position.x) * 8.2), -9, 1); }

        shootinginterval -= Time.deltaTime * 2;

        //shooting
        if (Input.GetKey(KeyCode.Space) && shootinginterval < 0)
        {
            Spawner.SpawnBullet(1, transform.position);
            shootinginterval = 1;
        }
    }
}
