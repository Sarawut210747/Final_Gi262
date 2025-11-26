using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    [Header("UI Panel")]
    public GameObject panel;

    [Header("Option Buttons (3 ปุ่ม)")]
    public Button[] optionButtons;

    [Header("Icon ของ Option")]
    public Image[] optionIcons;

    [Header("ชื่อของ Option")]
    public TMP_Text[] optionNames;

    private PlayerStats stats;

    private List<WeaponSO> allWeapons = new List<WeaponSO>();
    private List<AccessorySO> allAccessories = new List<AccessorySO>();

    private List<object> currentChoices = new List<object>();

    void Start()
    {
        stats = FindAnyObjectByType<PlayerStats>();

        // ดึงอาวุธทั้งหมดใน Resources/WeaponSO
        allWeapons.AddRange(Resources.LoadAll<WeaponSO>("WeaponSO"));

        // ดึง Accessories ทั้งหมดใน Resources/AccessorySO
        allAccessories.AddRange(Resources.LoadAll<AccessorySO>("AccessorySO"));

        panel.SetActive(false);
    }

    // เรียกใช้ตอนผู้เล่นเลเวลอัพ
    public void ShowUI()
    {
        panel.SetActive(true);
        Time.timeScale = 0f; // หยุดเกมเมื่ออัปเลเวล

        GenerateOptions();
    }

    public void HideUI()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    // --------------------------
    // สุ่มไอเท็มมาให้เลือก
    // --------------------------
    void GenerateOptions()
    {
        currentChoices.Clear();

        List<object> list = new List<object>();

        // อาวุธที่ยังไม่ Max level
        foreach (var w in allWeapons)
        {
            int lv = stats.GetWeaponLevel(w);
            if (lv < w.maxLevel)
                list.Add(w);
        }

        // Accessories ที่ยังไม่ Max
        foreach (var a in allAccessories)
        {
            int lv = stats.GetAccessoryLevel(a);
            if (lv < a.maxLevel)
                list.Add(a);
        }

        // สุ่มแค่ 3 ตัวเลือก
        for (int i = 0; i < 3; i++)
        {
            object choice = list[Random.Range(0, list.Count)];
            currentChoices.Add(choice);
            SetOptionUI(i, choice);
        }
    }

    // ใส่ข้อมูลลงปุ่ม UI
    void SetOptionUI(int index, object data)
    {
        if (data is WeaponSO weapon)
        {
            optionNames[index].text = $"{weapon.weaponName} (Lv {stats.GetWeaponLevel(weapon)})";
            optionIcons[index].sprite = weapon.icon;
        }
        else if (data is AccessorySO acc)
        {
            optionNames[index].text = $"{acc.itemName} (Lv {stats.GetAccessoryLevel(acc)})";
            optionIcons[index].sprite = acc.icon;
        }

        int i = index;
        optionButtons[index].onClick.RemoveAllListeners();
        optionButtons[index].onClick.AddListener(() => Select(i));
    }

    // --------------------------
    // เมื่อกดปุ่มเลือก
    // --------------------------
    void Select(int index)
    {
        object choice = currentChoices[index];

        if (choice is WeaponSO weapon)
            stats.LevelUpWeapon(weapon);

        if (choice is AccessorySO acc)
            stats.LevelUpAccessory(acc);

        HideUI();
    }
}
