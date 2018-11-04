using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.layer.Equals(14))
        {

            Destroy(col.gameObject);
            gameObject.GetComponentInParent<Boss>().kbHit();
        }

        else if (col.gameObject.layer.Equals(11))
        {

            col.gameObject.GetComponent<ShipMovement>().TakeDamage();
        }
    }
}
