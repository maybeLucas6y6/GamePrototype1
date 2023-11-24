using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject canvas;
    private CanvasGroup canvasGroup;
    private GameObject oldParentGameObject;
    private ItemProvenience oldItemProvenience;
    private PlayerInteraction playerInteraction;

    private void Awake()
    {
        if (transform.parent != null && transform.parent.transform.parent != null)
        {
            canvas = transform.parent.gameObject.transform.parent.transform.parent.gameObject;
        }
        canvasGroup = GetComponent<CanvasGroup>();
        playerInteraction = GameObject.Find("Player").GetComponent<PlayerInteraction>();
    }

    public void SetCanvas(GameObject t)
    {
        canvas = t.transform.parent.gameObject;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        oldParentGameObject = transform.parent.gameObject;
        oldItemProvenience = transform.parent.GetComponent<InventorySlot>().itemProvenience;
        eventData.pointerDrag.transform.SetParent(canvas.transform);

        LootInventory.instance.holdItem = gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        eventData.pointerDrag.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (eventData.pointerDrag.transform.parent.gameObject == canvas)
        {
            eventData.pointerDrag.transform.SetParent(oldParentGameObject.transform);
            eventData.pointerDrag.transform.position = oldParentGameObject.transform.position;
        }
        else
        {
            var newItemProvenience = transform.parent.GetComponent<InventorySlot>().itemProvenience;
            if (newItemProvenience == ItemProvenience.PlayerInventory && oldItemProvenience == ItemProvenience.External)
            {
                InventorySystem.current.Add(GetComponent<ItemObject>().referenceItem, GetComponent<ItemObject>().amount);
            }
            else if (newItemProvenience == ItemProvenience.External && oldItemProvenience == ItemProvenience.PlayerInventory)
            {
                InventorySystem.current.Remove(GetComponent<ItemObject>().referenceItem, GetComponent<ItemObject>().amount);
            }
            playerInteraction.UpdateGear();
            if (LootInventory.instance.currentLootbag != null)
            {
                LootInventory.instance.currentLootbag.GetComponent<ShowLootbag>().UpdateInventory();
            }
        }
        LootInventory.instance.holdItem = null;
    }
}
