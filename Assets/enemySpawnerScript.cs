using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class enemySpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public static int movingdir = 1;
    public static float movespd = 3;

    public int width = 11;
    public int height = 5;
    private float centerx = 0;
    private float centery = -4;
    private float space = 1.5f;
    private float shooting = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                Instantiate(enemy, new Vector3(w * space - (centerx + (width * space / 2)), h * space - (centery + (height * space / 2)), 1), transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //inc the sh0oting

        //test if touches wall
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject i in enemys)
        {
            if (math.abs(i.transform.position.x) > 8.2)
            {
                ifwalltouches();
                break;
            }
        }
    }

    private void ifwalltouches()
    {
        UnityEngine.Debug.Log("working");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject i in enemys)
        {
            if (math.abs(i.transform.position.x) > 8.2 )
            {
                i.transform.position = new Vector3(math.sign(i.transform.position.x)*8.2f, i.transform.position.y, 1);
            }
            i.transform.Translate(Vector2.down * space);
        }
        movingdir *= -1;
        movespd += 0;
    }
}
