using UnityEngine;

[CreateAssetMenu(menuName = "Game/Character Spec")]
public class CharacterSpecSO : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite portrait;
    public GameObject playerPrefab;
}
