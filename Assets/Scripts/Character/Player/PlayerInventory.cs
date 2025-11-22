using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<WeaponSO, int> weaponLevels = new();
    public Dictionary<AccessorySO, int> accessoryLevels = new();

    public void AddWeapon(WeaponSO weapon)
    {
        if (!weaponLevels.ContainsKey(weapon))
            weaponLevels[weapon] = 1;
        else if (weaponLevels[weapon] < weapon.maxLevel)
            weaponLevels[weapon]++;
    }

    public void AddAccessory(AccessorySO item)
    {
        if (!accessoryLevels.ContainsKey(item))
            accessoryLevels[item] = 1;
        else if (accessoryLevels[item] < item.maxLevel)
            accessoryLevels[item]++;
    }
}
