using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static GameSession I;
    public CharacterSpecSO selectedCharacter;
    public MapDataSO selectedMap;

    void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetCharacter(CharacterSpecSO spec) => selectedCharacter = spec;
    public void SetMap(MapDataSO map) => selectedMap = map;
}
