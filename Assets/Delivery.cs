using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasOrder = false;
    SpriteRenderer spriteRenderer;

    [SerializeField] float timeBeforeDestroy = 2f;
    [SerializeField] Color32 hasOrderColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasNoOrderColor = new Color32(0, 0, 0, 0);

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided with smth");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Client" && hasOrder)
        {
            hasOrder = false;
            spriteRenderer.color = hasNoOrderColor;
            Debug.Log("Delivered Package");
        }
        else if (other.tag == "Order" && !hasOrder)
        {
            hasOrder = true;
            spriteRenderer.color = hasOrderColor;
            Destroy(other.gameObject, timeBeforeDestroy);
            Debug.Log("Picked up order");
        }
    }
}
