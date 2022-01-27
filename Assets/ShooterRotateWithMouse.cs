using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRotateWithMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turning();
        if ( Input.GetMouseButtonDown(0) && MouseManager.Instance.canShoot())
        {
            shoot();
        }
    }

    void turning()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
        //Debug.Log("mouse position " + Input.mousePosition+" "+ target);
        transform.right = target - transform.position;
    }

    void shoot()
    {
        GameObject prefab = Resources.Load<GameObject>("customer/customer");
        GameObject go = Instantiate(prefab, transform.position, transform.rotation);
        go.GetComponent<Customer>().init(transform.right);
        GameLoopManager.Instance.shootCustomer();
    }
}
