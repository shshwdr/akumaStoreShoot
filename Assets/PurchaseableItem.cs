using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PurchaseableItem : MonoBehaviour
{
    public float basePrice = 10;
    public int leftAmount = 10;

    public TMP_Text priceLabel;
    public TMP_Text amountLabel;

    public void purchase(Customer customer)
    {
        leftAmount -= 1;
        customer.purchase(basePrice);
        if(leftAmount <= 0)
        {
            Destroy(gameObject);
            return;
        }

        amountLabel.text = leftAmount.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        priceLabel.text = basePrice.ToString();
        amountLabel.text = leftAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
