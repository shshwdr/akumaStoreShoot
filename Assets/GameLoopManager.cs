using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : Singleton<GameLoopManager>
{
    public int currentDay = 1;
    public int customerCount = 3;
    public int currentCustomerCount;
    // Start is called before the first frame update
    void Start()
    {
        currentCustomerCount = customerCount;
        EventPool.Trigger("updateCustomers");
    }
    public bool canShoot()
    {
        return true;
    }

    public void gotoNextDay()
    {
        currentCustomerCount = customerCount;

        EventPool.Trigger("updateCustomers");
    }
    public void shootCustomer()
    {
        currentCustomerCount -= 1;
        if(currentCustomerCount <= 0)
        {
            MouseManager.Instance.finishDay();
            Doozy.Engine.GameEventMessage.SendEvent("startSelectingItem");
        }

        EventPool.Trigger("updateCustomers");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
