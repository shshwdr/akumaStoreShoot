using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    Rigidbody2D rb;
    public float startSpeed = 7;
    public float walkoutSpeed = 1;
    bool finishedShopping = false;

    public float purchasedAmount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void init(Vector3 shootDir)
    {
        rb = GetComponent<Rigidbody2D>();
        //transform.forward = shootDir;
        rb.velocity = shootDir * startSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!finishedShopping)
        {

            var checkoutCounter = collision.GetComponent<CheckoutCounter>();
            if (checkoutCounter)
            {
                checkoutCounter.Checkout(this);
                finishedShopping = true;
                rb.velocity = new Vector2(0, walkoutSpeed);
                GetComponent<Collider2D>().isTrigger = true;
                Destroy(gameObject, 10);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var item = collision.collider. GetComponent<PurchaseableItem>();
        if (item)
        {
            item.purchase(this);
        }
    }

    public void purchase(float purchaseValue)
    {
        purchasedAmount += purchaseValue;
    }

}
