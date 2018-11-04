using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour {

    float hp = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hp == 0)
        {
            //gameObject.GetComponentInParent<Boss>().zoneDestroy();
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.layer.Equals(14))
        {

            Destroy(col.gameObject);
            hp--;
        }

        else if (col.gameObject.layer.Equals(11))
        {

            col.gameObject.GetComponent<ShipMovement>().TakeDamage();
        }
    }
}
