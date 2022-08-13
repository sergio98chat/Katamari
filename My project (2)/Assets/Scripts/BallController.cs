using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private float rollSpeed;
    [SerializeField] private Rigidbody rb;
    public float size = 1;

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
            collision.transform.parent = transform;
            size += collision.transform.localScale.magnitude;
        }
    }
}
