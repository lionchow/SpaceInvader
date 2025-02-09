using System.Xml.Serialization;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField] private bulletSpawnerScript Spawner;
    private float shootingtimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootingtimer += Time.deltaTime; 

        transform.Translate(new Vector2(enemySpawnerScript.movingdir, 0) * enemySpawnerScript.movespd * Time.deltaTime);
        
        /*if (shootingtimer > shootingInterval) 
        {
            shootingtimer = 0;
            Spawner.SpawnBullet(-1, transform.position);
            shootingInterval = UnityEngine.Random.Range(2.0f, 6.0f);
        }*/
    }
}
