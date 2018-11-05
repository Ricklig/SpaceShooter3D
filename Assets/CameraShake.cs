using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    Vector3 finalDir = new Vector3(0, 0, 0);
    Vector3 temp = new Vector3(0, 0, -12);
    float zval = -12f;
    Vector3 position;

    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        transform.position = GameObject.FindWithTag("Finish").GetComponent<Transform>().position + temp;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;

    }
}
