using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance;
    public CharacterSpecSO selectedCharacter;
    public MapDataSO selectedMap;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetCharacter(CharacterSpecSO spec) => selectedCharacter = spec;
    public void SetMap(MapDataSO map) => selectedMap = map;
}
