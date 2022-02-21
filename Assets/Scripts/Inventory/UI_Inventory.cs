using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
 /*   Inventory playerInventory;
    public Transform inventoryContainer;
    public Transform itemSlotTemplate;
    private RectTransform[] UIItemSlots;
    private Button[] buttons;
    private Slot pickedItem = new Slot();
    private RectTransform pickedItemSlot;
    private void Awake()
    {
        //itemSlotTemplate = inventoryContainer.Find("containerTemplate");
        pickedItemSlot = Instantiate(itemSlotTemplate, this.transform).GetComponent<RectTransform>();
    }

    void pickItem(int index) 
    {
        pickedItem = playerInventory.getInventory[index].copy();
        playerInventory.getInventory[index].clear();
        UIItemSlots[index].GetChild(0).Find("Icon").gameObject.SetActive(false);
    }
    void placeItem() 
    {
    
    }
    public void buttonEvent(int index) 
    {
        if (pickedItem.ItemType == null && playerInventory.getInventory[index].ItemType != null)
        {
            pickItem(index);
        }
        else
        {
            if (pickedItem.ItemType != null) 
            {
                int rest = playerInventory.addItemAt(index, pickedItem.ItemType, pickedItem.Count);
                if (rest == 0)
                {
                    pickedItem.clear();
                }
                else
                {
                    pickedItem.Count = rest;
                }
                //placeItem(index);
            }

        }
        
        //Debug.Log("button " + index + " has been pressed!");
    }
    public void setInventory(Inventory inventory) 
    {
        playerInventory = inventory;
        inventory.onItemChangedCallback += updateInventory;
        updateInventory();
    }
    private void Update()
    {
        //buttons[index] = itemSlotRectTransform.Find("Button").GetComponent<Button>();
        //itemSlotRectTransform.Find("Button").GetComponent<Identity>().index = index;
        //buttons[index].onClick.AddListener(() => buttonEvent(itemSlotRectTransform.Find("Button").GetComponent<Identity>().index));
        pickedItemSlot.anchoredPosition = new Vector2(Input.mousePosition.x, 0);
        pickedItemSlot.gameObject.SetActive(true);
        pickedItemSlot.gameObject.name = "pickedItem";

        if (pickedItem.ItemType != null)
        {
            Transform item = pickedItemSlot.GetChild(0).Find("Icon");
            item.gameObject.SetActive(true);
            item.GetComponent<Image>().sprite = pickedItem.ItemType.sprite;
        }
        else 
        {
            Transform item = pickedItemSlot.GetChild(0).Find("Icon");
            item.gameObject.SetActive(false);
        }
    }
    private void updateInventory()
    {
        
        int rows = 2;
        int columns = 4;
        float slotSize = 95;
        int x = 0;
        int y = 0;
        int index = 0;
        if (UIItemSlots != null) {
            foreach (RectTransform ItemSLot in UIItemSlots)
            {
                Destroy(ItemSLot.gameObject);
            }
        }
        
        UIItemSlots = new RectTransform[playerInventory.getInventory.Count];
        buttons = new Button[playerInventory.getInventory.Count];
        //inventoryContainer.GetComponent<RectTransform>().
        foreach (Slot slot in playerInventory.getInventory) 
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, inventoryContainer).GetComponent<RectTransform>();
            buttons[index] = itemSlotRectTransform.Find("Button").GetComponent<Button>();
            itemSlotRectTransform.Find("Button").GetComponent<Identity>().index = index;
            buttons[index].onClick.AddListener(() => buttonEvent(itemSlotRectTransform.Find("Button").GetComponent<Identity>().index));
            itemSlotRectTransform.anchoredPosition = new Vector2(x* slotSize + slotSize * 0.5f,y * slotSize - slotSize * 0.5f );
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.gameObject.name = "ItemSlot" + index;

            if (slot.ItemType != null) 
            {
                Transform item = itemSlotRectTransform.GetChild(0).Find("Icon");
                Transform itemCount = itemSlotRectTransform.GetChild(0).Find("Count");
                item.gameObject.SetActive(true);
                item.GetComponent<Image>().sprite = slot.ItemType.sprite;
                if (slot.Count > 1) 
                {
                    itemCount.gameObject.SetActive(true);
                    itemCount.GetComponent<TextMeshProUGUI>().text = slot.Count.ToString();
                }
            }
            x++;
            if (x > 3) 
            {
                x = 0;
                y--;
            }
            UIItemSlots[index] = itemSlotRectTransform;
            index++;
        }
    }*/
}
