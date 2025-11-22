using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    public GameObject panel;

    public WeaponSO[] weapons;
    public AccessorySO[] accessories;

    PlayerInventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<PlayerInventory>();
    }

    public void ShowOptions()
    {
        panel.SetActive(true);
        Generate3RandomChoices();
    }

    void Generate3RandomChoices()
    {
        // Random ง่ายๆ: 50% weapon / 50% accessory
        // จะสุ่ม 3 ปุ่มให้ผู้เล่นเลือก

        // TODO: ทำ UI ปุ่ม 3 ปุ่มแบบจริง
    }

    public void ChooseWeapon(WeaponSO weapon)
    {
        inventory.AddWeapon(weapon);
        Close();
    }

    public void ChooseAccessory(AccessorySO acc)
    {
        inventory.AddAccessory(acc);
        Close();
    }

    void Close()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
