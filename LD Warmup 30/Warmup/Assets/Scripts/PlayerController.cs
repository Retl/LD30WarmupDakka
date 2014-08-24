using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float horiz = 0;
    public float vert = 0;
    public float movespeed = 128;

    public bool abilityOne = false;

    public float shotCooldownTimer = 0.0f;
    public float shotCooldown = 0.1f;

    public GameObject mainShotStyle;
    public GameObject secondaryShotStyle;
    public GameObject thirdShotStyle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
    {

        if (shotCooldownTimer > 0)
        {
            shotCooldownTimer -= Time.deltaTime;
        }

        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        abilityOne = Input.GetButton("Fire1");

        gameObject.rigidbody2D.velocity = new Vector2(horiz * movespeed * Time.deltaTime, vert * movespeed * Time.deltaTime);

        if (shotCooldownTimer <= 0 && abilityOne && mainShotStyle != null)
        {
            //Upper shot.
            Instantiate(mainShotStyle, transform.position, Quaternion.identity);
            //Lower shot.
            GameObject shot = Instantiate(mainShotStyle, transform.position, Quaternion.identity) as GameObject;
            WaveShot shotScript = shot.GetComponent<WaveShot>();
            if (shotScript != null)
            {
                shotScript.InvertVertical();
            }

            //Middle shot.
            Instantiate(secondaryShotStyle, transform.position, Quaternion.identity);

			//Play the sound effect.
            audio.Play();

            shotCooldownTimer += shotCooldown;
        }
	
	}
}
