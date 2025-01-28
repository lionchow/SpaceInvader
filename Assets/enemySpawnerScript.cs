using UnityEngine;

public class enemySpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public int width = 15;
    public int height = 5;
    public float centerx = 0;
    public float centery = -4;
    public float space = 1.5f;

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
        
    }
}
