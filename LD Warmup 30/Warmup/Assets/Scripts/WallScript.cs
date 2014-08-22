using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Destroy bullets that hit walls.
    void OnTriggerEnter2D (Collider2D col) {
        Debug.Log("Entry.");
        if (col.gameObject.GetComponent<WaveShot>() != null)
        {
            Destroy(col.gameObject);
            Debug.Log("BOOM.");
        }
	}
}
