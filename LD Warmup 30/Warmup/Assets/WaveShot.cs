using UnityEngine;
using System.Collections;

public class WaveShot : MonoBehaviour {

    public float lifetime = 3.0f;
    public float hspeed = 12.8f;
    public float vspeed = 32.0f;
    public float vamp = 10.0f;
    public float varc = 0.0f;


	// Use this for initialization
	void Start () {
	    gameObject.rigidbody2D.velocity = new Vector2(hspeed, System.Convert.ToSingle(System.Math.Sin(varc)) * vspeed * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update()
    {
        lifetime -= Time.deltaTime;
        varc += 10 * Time.deltaTime;
        /*
        if (varc > 2.0f)
        {
            varc -= 2.0f;
        }
        */

        if (gameObject.GetComponent<Rigidbody2D>() != null)
        {
            gameObject.rigidbody2D.velocity = new Vector2(gameObject.rigidbody2D.velocity.x, System.Convert.ToSingle(System.Math.Sin(varc)) * vspeed * vamp * Time.deltaTime);
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
}
