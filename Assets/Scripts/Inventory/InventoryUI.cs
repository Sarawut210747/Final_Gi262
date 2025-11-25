using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public PlayerInventory inventory;

    public ItemSlot[] weaponSlots;
    public ItemSlot[] accessorySlots;

    public void Refresh()
    {

        // เติมอาวุธ
        for (int i = 0; i < inventory.currentWeapons.Count && i < weaponSlots.Length; i++)
            weaponSlots[i].SetWeapon(inventory.currentWeapons[i]);

        // เติม accessory
        for (int i = 0; i < inventory.currentAccessories.Count && i < accessorySlots.Length; i++)
            accessorySlots[i].SetAccessory(inventory.currentAccessories[i]);
    }
}
