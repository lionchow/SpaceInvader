using UnityEngine;

public class bulletSpawnerScript : MonoBehaviour
{
    public GameObject Bullet;

    public void SpawnBullet(int dir, Vector3 position)
    {
        GameObject bullet = Instantiate(Bullet, position, transform.rotation);
        bullet.GetComponent<bulletScript>().dir = dir;
    }
}
