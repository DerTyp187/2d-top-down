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
    public void setInventory(Inventory inventory) 
    {
        playerInventory = inventory;
        updateInventory();
    }
    private void updateInventory()
    {
        int x = 0;
        int y = 0;
        float slotSize = 100;
        foreach (Slot slot in playerInventory.getInventory) 
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, inventoryContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.anchoredPosition = new Vector2(x* slotSize,y * slotSize);
            itemSlotRectTransform.gameObject.SetActive(true);
            

            if (slot.ItemType != null) 
            {
                Transform Item = itemSlotRectTransform.Find("ItemTemplate");
                Item.gameObject.SetActive(true);
                Item.GetComponent<Image>().sprite = slot.ItemType.sprite;
            }
            x++;
            if (x > 3) 
            {
                x = 0;
                y--;
            }
        }
    }
}
