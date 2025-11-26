using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Base Stats")]
    public float maxHP = 100;
    public float attack = 10;
    public float moveSpeed = 3;

    [Header("Inventory Data")]
    public List<WeaponSO> weapons = new List<WeaponSO>();
    public List<AccessorySO> accessories = new List<AccessorySO>();

    // เก็บเลเวลแบบเป็น Dictionary
    public Dictionary<WeaponSO, int> weaponLevels = new Dictionary<WeaponSO, int>();
    public Dictionary<AccessorySO, int> accessoryLevels = new Dictionary<AccessorySO, int>();

    private void Start()
    {
        // เริ่มต้นให้ทุกอาวุธเลเวล 1
        foreach (var w in weapons)
        {
            if (!weaponLevels.ContainsKey(w))
                weaponLevels[w] = 1;
        }

        // เริ่มต้น Accessory เลเวล 1
        foreach (var a in accessories)
        {
            if (!accessoryLevels.ContainsKey(a))
                accessoryLevels[a] = 1;
        }
    }

    // ================ Weapon ===================

    public int GetWeaponLevel(WeaponSO weapon)
    {
        if (weaponLevels.ContainsKey(weapon))
            return weaponLevels[weapon];

        return 0;
    }

    public void LevelUpWeapon(WeaponSO weapon)
    {
        if (!weaponLevels.ContainsKey(weapon))
            weaponLevels[weapon] = 1;

        int lv = weaponLevels[weapon];

        if (lv < weapon.maxLevel)
        {
            weaponLevels[weapon]++;
            ApplyWeaponBonus(weapon);
        }
    }

    private void ApplyWeaponBonus(WeaponSO weapon)
    {
        attack += weapon.damagePerLevel[weaponLevels[weapon] - 1];
    }

    // ================ Accessory ===================

    public int GetAccessoryLevel(AccessorySO acc)
    {
        if (accessoryLevels.ContainsKey(acc))
            return accessoryLevels[acc];

        return 0;
    }

    public void LevelUpAccessory(AccessorySO acc)
    {
        if (!accessoryLevels.ContainsKey(acc))
            accessoryLevels[acc] = 1;

        int lv = accessoryLevels[acc];

        if (lv < acc.maxLevel)
        {
            accessoryLevels[acc]++;
            ApplyAccessoryBonus(acc);
        }
    }

    private void ApplyAccessoryBonus(AccessorySO acc)
    {
        maxHP += acc.hpBonus;
        moveSpeed += acc.speedBonus;
    }
}
