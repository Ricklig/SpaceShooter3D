using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    void Update()
    {
        if ((transform.position.z - GameObject.FindWithTag("Player").transform.position.z) > 80)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.layer.Equals(13))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);

        }
        else if (col.gameObject.layer.Equals(14))
        {

            Destroy(col.gameObject);
            Destroy(gameObject);

        }
        Destroy(gameObject);
    }
}
