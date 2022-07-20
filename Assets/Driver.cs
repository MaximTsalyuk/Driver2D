using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    float currentSpeed;

    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] float rotateSpeed = 0.1f;
    [SerializeField] float fastSpeed = 0.02f;
    [SerializeField] float slowSpeed = 0.008f;


    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUp")
        {
            currentSpeed = fastSpeed;
        }
        else if (other.tag == "SpeedDown")
        {
            currentSpeed = slowSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
