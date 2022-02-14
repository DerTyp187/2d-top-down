using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    Inventory playerInventory;
    public Transform inventoryContainer;
    public Transform itemSlotTemplate;
    private void Awake()
    {
        //itemSlotTemplate = inventoryContainer.Find("containerTemplate");
    }
    public void buttonEvent(int index) 
    {
        Debug.Log("yeet");
    }
    public void setInventory(Inventory inventory) 
    {
        playerInventory = inventory;
        inventory.onItemChangedCallback += updateInventory;
        updateInventory();
    }
    private void updateInventory()
    {
        
        int rows = 2;
        int columns = 4;
        float slotSize = 95;
        int x = 0;
        int y = 0;
        int index = 0;
        //inventoryContainer.GetComponent<RectTransform>().
        foreach (Slot slot in playerInventory.getInventory) 
        {

            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, inventoryContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.anchoredPosition = new Vector2(x* slotSize + slotSize * 0.5f,y * slotSize - slotSize * 0.5f );
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.gameObject.name = "ItemSlot" + index;

            if (slot.ItemType != null) 
            {
                Transform Item = itemSlotRectTransform.GetChild(0).Find("Icon");
                Item.gameObject.SetActive(true);
                Item.GetComponent<Image>().sprite = slot.ItemType.sprite;
            }
            x++;
            if (x > 3) 
            {
                x = 0;
                y--;
            }
            index++;
        }
    }
}
