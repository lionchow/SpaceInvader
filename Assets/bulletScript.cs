using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int dir = 0;
    private float movespd = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, dir, 0) * movespd * Time.deltaTime);
        if (transform.position.y < -10) { Destroy(gameObject); }
    }
}
