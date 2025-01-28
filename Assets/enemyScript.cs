using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField] private bulletSpawnerScript Spawner;

    private float swingMagnitude = 1.5f;
    private float shootingtimer = 0;
    private float movementtimer = 0;
    private float shootingInterval; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootingInterval = UnityEngine.Random.Range(2.0f, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        shootingtimer += Time.deltaTime;
        movementtimer += Time.deltaTime;
        transform.Translate(new Vector2(math.sin(movementtimer), 0) * swingMagnitude * Time.deltaTime);

        if (shootingtimer > shootingInterval) 
        {
            shootingtimer = 0;
            Spawner.SpawnBullet(-1, transform.position);
            shootingInterval = UnityEngine.Random.Range(2.0f, 6.0f);
        }
    }
}
