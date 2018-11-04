using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3(0.0f,  0.0f,3*Time.deltaTime);
        transform.Translate(movement); 
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.layer.Equals(14))
        {

            Destroy(col.gameObject);
            gameObject.GetComponentInParent<EnemyAManager>().sendPos(gameObject.transform.position);
            //GameObject.FindWithTag("GameController").GetComponent<GameManager>().updateScore(100);
            transform.rotation = Quaternion.Euler(0, -1, 0);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

        else if (col.gameObject.layer.Equals(9))
        {
            
            gameObject.GetComponentInParent<EnemyAManager>().noBonus();
            Destroy(gameObject);
        }

        else if (col.gameObject.layer.Equals(11))
        {
            
            col.gameObject.GetComponent<ShipMovement>().TakeDamage();
            gameObject.GetComponentInParent<EnemyAManager>().noBonus();
            Destroy(gameObject);
        }
        else if (col.gameObject.layer.Equals(4))
        {
            Destroy(gameObject);
        }
    }

}
