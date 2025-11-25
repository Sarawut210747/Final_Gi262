using UnityEngine;

public class InventoryItemPanel : MonoBehaviour
{
    public static InventoryItemPanel Instance;

    [Header("UI Container")]
    public Transform itemContainer;        // ที่วาง ItemSlot ในหน้า Inventory

    [Header("Prefab")]
    public GameObject itemSlotPrefab;      // Prefab ของ ItemSlot

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// อัปเดตช่อง Inventory ทั้งหมดให้ตรงกับ PlayerInventory
    /// </summary>
    public static void UpdateItems(PlayerStats stats)
    {
        // 1. ลบช่องเก่าออกจาก Scene (แต่ไม่ลบ asset)
        foreach (Transform t in Instance.itemContainer)
        {
            Destroy(t.gameObject);    // ปลอดภัย เพราะลบเฉพาะ instance ใน Scene
        }

        // 2. เติม Weapon Slots ใหม่
        foreach (var w in stats.weapons)
        {
            GameObject slot = Instantiate(Instance.itemSlotPrefab, Instance.itemContainer);
            slot.GetComponent<ItemSlot>().SetWeapon(w);
        }

        // 3. เติม Accessories Slots ใหม่
        foreach (var acc in stats.accessories)
        {
            GameObject slot = Instantiate(Instance.itemSlotPrefab, Instance.itemContainer);
            slot.GetComponent<ItemSlot>().SetAccessory(acc);
        }
    }
}
