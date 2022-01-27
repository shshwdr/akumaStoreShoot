using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class SelectionController : MonoBehaviour
{
    public Transform contentParent;

    protected abstract List<InfoBase> allItems();

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (!contentParent)
        {
            contentParent = transform;
        }
        updateUI();
    }
    public void updateUI()
    {

        int i = 0;
        var items = allItems();
        
        for (; i < contentParent.childCount; i++)
        {
            contentParent.GetChild(i).gameObject.SetActive(true);
            var rand = Random.Range(0, items.Count);
            BuildItemButton button = contentParent.GetChild(i).GetComponent<BuildItemButton>();
            button.init(items[rand]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
