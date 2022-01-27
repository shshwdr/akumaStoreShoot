using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseableItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject itemPrefab = Resources.Load<GameObject>("item");
        GridManager.Instance.randomlyGenerateItem(itemPrefab);
        GridManager.Instance.randomlyGenerateItem(itemPrefab);
        GridManager.Instance.randomlyGenerateItem(itemPrefab);
        GridManager.Instance.randomlyGenerateItem(itemPrefab);
        GridManager.Instance.randomlyGenerateItem(itemPrefab);
    }

    public Dictionary<string, RoomItemInfo> mainItemInfoDict = new Dictionary<string, RoomItemInfo>();
    public Dictionary<string, RoomItemInfo> decoItemInfoDict = new Dictionary<string, RoomItemInfo>();
    public Dictionary<string, List<DraggableItem>> items = new Dictionary<string, List<DraggableItem>>();
    // Start is called before the first frame update
    void Awake()
    {
        string text = Resources.Load<TextAsset>("json/item").text;
        var allNPCs = JsonMapper.ToObject<AllRoomItemInfo>(text);
        foreach (RoomItemInfo info in allNPCs.allMainItem)
        {
            mainItemInfoDict[info.name] = info;
        }
        foreach (RoomDecorationInfo info in allNPCs.allDecorations)
        {
            decoItemInfoDict[info.name] = info;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
