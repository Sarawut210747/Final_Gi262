using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Current Stats UI")]
    public TMPro.TMP_Text statusSkillText;
    public TMPro.TMP_Text skillText;
    public TMPro.TMP_Text passiveText;
    public TMPro.TMP_Text hpText;
    public TMPro.TMP_Text attackText;

    [Header("Items")]
    public List<WeaponSO> currentWeapons = new List<WeaponSO>();
    public List<AccessorySO> currentAccessories = new List<AccessorySO>();

    // ระบบเลเวลอาวุธและไอเทม
    public Dictionary<WeaponSO, int> weaponLevels = new Dictionary<WeaponSO, int>();
    public Dictionary<AccessorySO, int> accessoryLevels = new Dictionary<AccessorySO, int>();

    PlayerStats stats;

    private void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    // ------------------------------------------------------
    // เพิ่มอาวุธ
    // ------------------------------------------------------
    public void AddWeapon(WeaponSO weapon)
    {
        if (!weaponLevels.ContainsKey(weapon))
        {
            currentWeapons.Add(weapon);
            weaponLevels.Add(weapon, 1);

            stats.attackDamage += weapon.attackBonus;
            UpdateUI();
            return;
        }

        // อัปเลเวลเพิ่ม
        if (weaponLevels[weapon] < weapon.maxLevel)
        {
            weaponLevels[weapon]++;
            stats.attackDamage += weapon.attackBonus;
        }

        UpdateUI();
    }

    // ------------------------------------------------------
    // เพิ่ม Accessory
    // ------------------------------------------------------
    public void AddAccessory(AccessorySO item)
    {
        if (!accessoryLevels.ContainsKey(item))
        {
            currentAccessories.Add(item);
            accessoryLevels.Add(item, 1);

            stats.maxHP += item.hpBonus;
            stats.moveSpeed += item.speedBonus;
            UpdateUI();
            return;
        }

        if (accessoryLevels[item] < item.maxLevel)
        {
            accessoryLevels[item]++;
            stats.maxHP += item.hpBonusPerLevel;
            stats.moveSpeed += item.speedBonusPerLevel;
        }

        UpdateUI();
    }

    // ------------------------------------------------------
    // อัปเดต UI
    // ------------------------------------------------------
    public void UpdateUI()
    {
        hpText.text = "HP : " + stats.currentHP + "/" + stats.maxHP;
        attackText.text = "ATK : " + stats.attackDamage;
    }
}
