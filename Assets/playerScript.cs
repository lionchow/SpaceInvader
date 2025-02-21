using Unity.Mathematics;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private float shootinginterval = 0;
    public int movespd;

    // Update is called once per frame
    void Update()
    {
        //movement
        if (Input.GetKey(KeyCode.A)) { transform.Translate(movespd * Time.deltaTime * Vector2.left); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(movespd * Time.deltaTime * Vector2.right); }
        if (math.abs(transform.position.x) > 8.2) { transform.position = new Vector3((float)(math.sign(transform.position.x) * 8.2), -9, 1); }

        shootinginterval -= Time.deltaTime * 2;

        //shooting
        if (Input.GetKey(KeyCode.Space) && shootinginterval < 0)
        {
            GameObject b = Instantiate(bullet, transform.position, transform.rotation);
            b.GetComponent<bulletScript>().dir = 1;
            shootinginterval = 1;
        }
    }
}
