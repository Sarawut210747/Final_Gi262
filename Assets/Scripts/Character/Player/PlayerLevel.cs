using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int level = 1;
    public int currentExp = 0;
    public int expToNext = 20;

    public LevelUpUI levelUpUI;

    public void AddExp(int amount)
    {
        currentExp += amount;

        if (currentExp >= expToNext)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        currentExp = 0;
        expToNext += 10;

        Debug.Log("LEVEL UP!");

        Time.timeScale = 0f; // หยุดเกมให้เลือกไอเทม
        levelUpUI.ShowOptions();
    }
}
