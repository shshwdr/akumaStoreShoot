using Pool;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateHud : MonoBehaviour
{
    public TMP_Text leftDaysLabel;
    public TMP_Text payTargetLabel;
    public TMP_Text currentMoenyLabel;
    public TMP_Text custoemrLeftLabel;
    // Start is called before the first frame update
    void Start()
    {
        EventPool.OptIn("updateCoins", updateCoins);
        EventPool.OptIn("updateCustomers", updateCustomerLeft);
    }

    void updateCoins()
    {
        currentMoenyLabel.text = Inventory.Instance.coins.ToString()+"yuan";
    }

    void updateCustomerLeft()
    {
        custoemrLeftLabel.text = "Customer Left: "+GameLoopManager.Instance.currentCustomerCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
