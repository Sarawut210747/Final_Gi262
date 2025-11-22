using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [Header("Assigned at Start")]
    public CharacterSpecSO spec; // ตัวละครที่เลือกจากเมนู

    [Header("Runtime Stats")]
    public float currentHP;
    public float moveSpeed;
    public int damage;

    public int killCount = 0;

    private SkillManager skillManager;

    void Start()
    {
        spec = GameSession.Instance.selectedCharacter;
        if (spec == null)
        {
            Debug.LogError("SPEC IS NULL !!!");
            return;
        }
        // โหลดค่าจากตัวละครที่เลือก
        currentHP = spec.maxHP;
        moveSpeed = spec.moveSpeed;
        damage = spec.baseDamage;

        skillManager = GetComponent<SkillManager>();
        skillManager.Setup(spec);
    }

    public void OnEnemyKilled()
    {
        killCount++;

        // Passive Vampire = kill ครบ 20 → ระเบิดเลือด
        if (spec.type == CharacterType.Vampire && killCount >= 20)
        {
            killCount = 0;
            skillManager.TriggerVampirePassive();
        }
    }
    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        Debug.Log("Player HP = " + currentHP);

        if (currentHP <= 0)
        {
            Debug.Log("PLAYER DEAD");
        }
    }
    public void Die()
    {
        // SceneManager.LoadScene("");
        Destroy(gameObject);

        Debug.Log("แฮม");
    }
}
