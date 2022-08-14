using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private float rollSpeed;
    [SerializeField] private Rigidbody rb;
    public float size = 1;

    public GameObject FloatText;

    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        Vector3 movement = (input.z * CameraTransform.forward) + (input.x * CameraTransform.right);

        rb.AddForce(movement * rollSpeed * Time.fixedDeltaTime * size);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "prop" && collision.transform.localScale.magnitude <= size)
        {
            float objSize = collision.transform.localScale.magnitude;
            collision.transform.parent = transform;
            size += objSize;
            if (FloatText)
            {
                FloatTextActivate(objSize);
            }
        }
    }

    void FloatTextActivate(float objSize)
    {
        var go = Instantiate(FloatText, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = "+"+objSize.ToString("#.###");
    }
}
