using UnityEngine;
using System.Collections;

public class StraightShot : MonoBehaviour {

    public float lifetime = 3.0f;
    public float hspeed = 12.8f;
    public float vspeed = 0;

    private Vector2 startingVelocity;
    
    
    // Use this for initialization
    void Start () {
        startingVelocity = new Vector2(hspeed, vspeed);
        gameObject.rigidbody2D.velocity = startingVelocity;
    }
    
    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        
        if (gameObject.GetComponent<Rigidbody2D>() != null)
        {
            gameObject.rigidbody2D.velocity = startingVelocity;
        }
        
        if (LifetimeExpired())
        {
            Destroy(gameObject);
        }
        
    }
    
    protected bool LifetimeExpired()
    {
        return lifetime <= 0;
    }
    
    public void InvertVertical()
    {
        vspeed = -vspeed;
    }
}
