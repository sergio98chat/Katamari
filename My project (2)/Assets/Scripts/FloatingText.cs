using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float DestroyTime = 4f;
    public Vector3 Offset = new Vector3(0, 2, 0);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
        transform.position += new Vector3(Random.Range(-2,2),2,Random.Range(-2,2));
    }
}
