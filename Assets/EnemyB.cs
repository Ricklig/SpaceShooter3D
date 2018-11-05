using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : MonoBehaviour {

    float CurveSpeed = 5;
    float MoveSpeed = 2;
    float fTime = 50;
    float runTime = 0f;
    bool shoot = false;
    
    public GameObject bulletPrefab;
    public Transform gun;

    float shotsFired = 4.0f;
    

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()

    {

        if (runTime < 4)
        {
            runTime += Time.deltaTime;
            transform.Translate(10f * Time.deltaTime,0.0f, 0.0f);
        }
        else if(runTime < 6)
        {
            shoot = false;
            shotsFired = 2.25f;
            runTime += Time.deltaTime;
            transform.Translate(0.0f,0.0f, 8f * Time.deltaTime);
        }
        else if (runTime < 10)
        {
            shoot = true;
            runTime += Time.deltaTime;
            transform.Translate(-10f * Time.deltaTime, 0.0f, 0.0f);
        }
        else if (runTime < 12)
        {
            shoot = false;
            shotsFired = 2.0f;
            runTime += Time.deltaTime;
            transform.Translate(0.0f, 0.0f, 8f * Time.deltaTime);
        }
        else if (runTime < 16)
        {
            shoot = true;
            runTime += Time.deltaTime;
            transform.Translate(5f * Time.deltaTime, 0.0f, 0.0f);
        }

        shotsFired -= Time.deltaTime;
        if(shotsFired < 0 && shoot)
        {
            Fire();
            shotsFired = 2.0f;
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.layer.Equals(14))
        {

            Destroy(col.gameObject);
            gameObject.GetComponentInParent<EnemyBManager>().sendPos(gameObject.transform.position);
            //GameObject.FindWithTag("GameController").GetComponent<GameManager>().updateScore(100);
            //transform.rotation = Quaternion.Euler(0, 0 ,);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

        else if (col.gameObject.layer.Equals(9))
        {

            gameObject.GetComponentInParent<EnemyBManager>().noBonus();
            Destroy(gameObject);
        }

        else if (col.gameObject.layer.Equals(11))
        {

            col.gameObject.GetComponent<ShipMovement>().TakeDamage();
            gameObject.GetComponentInParent<EnemyBManager>().noBonus();
            Destroy(gameObject);
        }
        else if (col.gameObject.layer.Equals(4))
        {
            Destroy(gameObject);
        }
    }

    void Fire()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            Vector3 vectorToTarget = GameObject.FindWithTag("Player").GetComponent<Transform>().position - gameObject.transform.position;
            Vector3 facingDirection = transform.forward; // just for clarity!

            float angleInDegrees = Vector3.Angle(facingDirection, vectorToTarget);
            Quaternion q = Quaternion.FromToRotation(facingDirection, vectorToTarget);
            var bullet = (GameObject)Instantiate(bulletPrefab, gun.position, q );
            bullet.GetComponent<Rigidbody>().AddForce(vectorToTarget * 0.5f, ForceMode.VelocityChange);

        }

    }

}
