using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;

public class enemySpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject bullet;

    public int movingdir = 1;

    public static float loopSpd = 2;

    //spawning var
    public int width = 11;
    public int height = 5;
    private float centerx = 0;
    private float centery = 4;
    private float space = 1.2f;

    //shooting var
    private float loop = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float lowX = centerx - (width * (space / 2));
        float lowY = centery - (height * (space / 2));

        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                if (h < 2)
                {
                    Instantiate(enemy1, new Vector3(lowX + (space * w), lowY + (space * h), 1), transform.rotation);
                } else
                {
                    GameObject enemy = Instantiate(enemy2, new Vector3(lowX + (space * w), lowY + (space * h), 1), transform.rotation);
                    enemyScript script = enemy.GetComponent<enemyScript>();
                    script.coloumns = w;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get all the enemys
        List<GameObject> enemy1 = GameObject.FindGameObjectsWithTag("enemy1").ToList();
        List<GameObject> enemy2 = GameObject.FindGameObjectsWithTag("enemy2").ToList();
        List<GameObject> enemys = enemy1;
        enemys.AddRange(enemy2);

        //inc the loop
        loop -= Time.deltaTime * loopSpd;

        //shoot bullet if loop
        if (loop < 0)
        {
            loop = 2;
            shootbullet(enemy2);
        }

        //test if touches wall
        foreach (GameObject i in enemys)
        {
            i.transform.Translate(loopSpd/1.5f * Time.deltaTime * new Vector2(movingdir, 0));
            if (math.abs(i.transform.position.x) > 8.2)
            {
                i.transform.position = new Vector3(math.sign(i.transform.position.x) * 8.2f, i.transform.position.y, 1);
                foreach(GameObject i2 in enemys)
                {
                    i2.transform.Translate(Vector2.down * space);
                }
                movingdir *= -1;
                break;
            }
        }
    }

    private void shootbullet(List<GameObject> enemy2)
    {
        //test for available columns
        List<int> availableColumns = new();
        foreach (GameObject i in enemy2)
        {
            enemyScript script = i.GetComponent<enemyScript>();
            if (!availableColumns.Contains(script.coloumns))
            {
                availableColumns.Add(script.coloumns);
            }
        }
        
        int index1 = availableColumns[UnityEngine.Random.Range(0, availableColumns.Count)];
        availableColumns.Remove(index1);
        int index2 = availableColumns[UnityEngine.Random.Range(0, availableColumns.Count)];

        //shoot
        foreach (GameObject i in enemy2)
        {
            enemyScript script = i.GetComponent<enemyScript>();
            if (script.coloumns == index1 || script.coloumns == index2)
            {
                if (script.checkcollision())
                {
                    GameObject b = Instantiate(bullet, i.transform.position, i.transform.rotation);
                    b.GetComponent<bulletScript>().dir = -1;
                }
            }
        }
    }
}
