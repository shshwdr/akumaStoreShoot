using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckoutCounter : MonoBehaviour
{
    public TMP_Text rateLabel;
    public float rate = 1;
    // Start is called before the first frame update
    void Start()
    {
        rateLabel.text = "x"+rate.ToString();
    }

    public void Checkout(Customer customer)
    {
        Inventory.Instance.addCoins(customer.purchasedAmount * rate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
