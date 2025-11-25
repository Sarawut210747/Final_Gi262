using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    public TMP_Text nameText;

    // สำหรับอาวุธ
    public void SetWeapon(WeaponSO weapon)
    {
        if (weapon == null) return;

        icon.sprite = weapon.icon;    // โชว์รูป
        icon.enabled = true;

        nameText.text = weapon.name;
    }

    // สำหรับ Accessory
    public void SetAccessory(AccessorySO acc)
    {
        if (acc == null) return;

        icon.sprite = acc.icon;       // โชว์รูป
        icon.enabled = true;

        nameText.text = acc.name;
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
    }
}
