using UnityEngine;
using UnityEngine.UI;
using Pool;
public enum MouseState { shoot,placeItem,none}
public class MouseManager : Singleton<MouseManager>
{
    MouseState state;
    Vector3 screenPoint;
    Camera dragCamera;
    public GameObject currentDragItem;
    public bool isInBuildMode;
    public GameObject selectedItem;
    public float rotateSmooth = 10.0f;

    public bool canShoot()
    {
        return state == MouseState.shoot;
    }

    public bool canPlaceItem()
    {
        return state == MouseState.placeItem;
    }

    public void selectItem()
    {
        state = MouseState.placeItem;
    }

    public void finishDay()
    {
        state = MouseState.none;
    }

    public void startShoot()
    {
        state = MouseState.shoot;
    }

    void selectItem(GameObject go)
    {
        selectedItem = go;
    }
    public void deselectIem()
    {
        selectedItem = null;
    }

    public void moveToGrid(Transform tran)
    {
        currentDragItem.transform.position = tran.position;
    }
    public void startDragItem(GameObject go)
    {
        selectItem();

        Doozy.Engine.GameEventMessage.SendEvent("selectItemToPurchase");
        if (currentDragItem)
        {
            Debug.Log("already have dragItem");
            Destroy(currentDragItem);
        }
        currentDragItem = go;
    }
    public void cancelCurrentDragItem()
    {
        if (currentDragItem)
        {
            Destroy(currentDragItem);
            currentDragItem = null;
            finishDay();
        }
    }

    public void finishCurrentDragItem()
    {

        if (currentDragItem && GridManager.Instance.canAddItem(currentDragItem.transform.position))
        {
            GridManager.Instance.addItem(currentDragItem.GetComponent<GridItem>());
            currentDragItem = null;

            Doozy.Engine.GameEventMessage.SendEvent("finishPlace");
            //currentDragItem.GetComponent<Draggable>().tryBuild();
            startShoot();

        }
    }

    public void startBuildMode()
    {
        isInBuildMode = true;
    }
    public void cancelDragItem(GameObject go)
    {
        if(currentDragItem != go)
        {
            Debug.LogError("cancel " + go + " is not the current one " + currentDragItem);
        }

        Destroy(currentDragItem);
        currentDragItem = null;
    }

    public void finishDragItem(GameObject go)
    {


        //if (currentDragItem && GridManager.Instance.canAddItem(currentDragItem.GetComponent<GridItem>()))
        //{
        //    GridManager.Instance.addItem(currentDragItem.GetComponent<GridItem>());
        //    currentDragItem = null;

        //    Doozy.Engine.GameEventMessage.SendEvent("finishPlace");
        //    //currentDragItem.GetComponent<Draggable>().tryBuild();
        //}

    }
    private void Start()
    {
        dragCamera = Camera.main;
        //Doozy.Engine.GameEventMessage.SendEvent("addItem");
    }



    private void Update()
    {
        if (currentDragItem)
        {
            //Vector3 mouseWorldPosition =  Utils.MouseWorldPosiiton();
            //Vector2Int mouseGridPosition = Utils.positionToGridIndex2d(mouseWorldPosition);
            //currentDragItem.transform.position = new Vector3(mouseGridPosition.x, mouseGridPosition.y,0);

            //screenPoint = dragCamera.WorldToScreenPoint(currentDragItem.transform.position);

            //float tilt = Input.GetAxisRaw("Rotate");
            //currentDragItem.transform.RotateAround(Vector3.zero, Vector3.up* tilt, rotateSmooth * Time.deltaTime);

            //var currentDraggable = currentDragItem.GetComponent<Draggable>();
            ////if (isDragging)
            //{
            //    bool canbuild = currentDraggable. canBuildItem();
            //    if (!canbuild)
            //    {
            //        currentDraggable.showDisableOverlay();
            //    }
            //    else
            //    {
            //        currentDraggable.showEnableOverlay();
            //    }

            //    Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            //    Vector3 mousePosition = dragCamera.ScreenToWorldPoint(newPosition);
            //    currentDraggable.transform.position = mousePosition;


            //}


        }




        //if (Input.GetMouseButtonDown(1))
        //{
        //    if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        //    {
        //        print("on ui");
        //        return;
        //    }
        //    Debug.Log("mouse down");

        //    if (currentDragItem)
        //    {
        //        currentDragItem.GetComponent<Draggable>().removeDragItem();
        //        return;
        //    }

        //    LayerMask mask = LayerMask.GetMask("item");
        //    if (currentDragItem == null && isInBuildMode )
        //    {
        //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //        foreach (var hit in Physics.RaycastAll(ray,1000, mask))
        //        {
        //            Debug.Log("hit " + hit.transform.gameObject);
        //            var hitItem = hit.transform.GetComponent<DraggableItem>();
        //            if (hitItem)
        //            {
        //                Doozy.Engine.GameEventMessage.SendEvent("ItemAction");
        //                selectItem(hit.transform.gameObject);
        //                return;
        //            }
        //        }
        //    }
        //    return;
        //}

        if (Input.GetMouseButton(0))
        {
            //if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            //{
            //    print("on ui");
            //    return;
            //}
            Vector3 mouseWorldPosition = Utils.MouseWorldPosiiton();
            if (currentDragItem && GridManager.Instance.canAddItem(mouseWorldPosition))
            {
                Vector2Int mouseGridPosition = Utils.positionToGridIndex2d(mouseWorldPosition);
                currentDragItem.transform.position = new Vector3(mouseGridPosition.x, mouseGridPosition.y, 0);

            }


            //if (selectedItem)
            //{
            //    deselectIem();

            //    Doozy.Engine.GameEventMessage.SendEvent("CancelItemAction");
            //}
            ////if (currentDragItem == null)
            ////{
            ////    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            ////    foreach (var hit in Physics.RaycastAll(ray))
            ////    {
            ////        Debug.Log("hit " + hit.transform.gameObject);
            ////        var hitItem = hit.transform.GetComponent<DraggableItem>();
            ////        if (hitItem)
            ////        {
            ////            if (hitItem.room.isEditing)
            ////            {
            ////                startDragItem(hitItem.gameObject);
            ////                return;
            ////            }
            ////        }
            ////    }
            ////}

            //return;
        }
    }

    //public void removeSelectedRoom()
    //{
    //    if(!selectedItem || !selectedItem.GetComponent<DraggableRoom>())
    //    {
    //        Debug.LogError(selectedItem + " is not a room that can be removed");
    //    }
    //    selectedItem.GetComponent<DraggableRoom>().cancelDragItem();
    //}

    //public void startDraggingRoom()
    //{
    //    if (!selectedItem || !selectedItem.GetComponent<DraggableRoom>())
    //    {
    //        Debug.LogError(selectedItem + " is not a room that can be moved");
    //    }
    //    selectedItem.GetComponent<DraggableRoom>().getIntoEditMode();
    //}

    //public void editSelectedRoomItems()
    //{
    //    if (!selectedItem || !selectedItem.GetComponent<DraggableRoom>())
    //    {
    //        Debug.LogError(selectedItem + " is not a room that can be moved");
    //    }
    //    selectedItem.GetComponent<DraggableRoom>().getIntoEditMode();
    //}

    public void removeCurrentSelect()
    {
        //pop up 
        selectedItem.GetComponent<Draggable>().removeDragItem();
    }
    public void moveCurrentSelect()
    {
        currentDragItem = selectedItem;
        currentDragItem.GetComponent<Draggable>().isDragging = true;
        selectedItem = null;
    }
    public void cancelSelect()
    {
        selectedItem = null;
    }
}