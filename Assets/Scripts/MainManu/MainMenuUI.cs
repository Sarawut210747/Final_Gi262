using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject characterPanel;

    [Header("Data")]
    public CharacterSpecSO[] characters;
    public MapDataSO[] maps;

    [Header("Character UI")]
    public Image portraitImage;
    public Text nameText;

    private int currentCharIndex = -1;

    void Start()
    {
        mainPanel.SetActive(true);
        characterPanel.SetActive(false);
    }

    // ========== MAIN ==========
    public void OnClickStart()
    {
        mainPanel.SetActive(false);
        characterPanel.SetActive(true);
        PickCharacter(0);
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // ========== CHARACTER SELECT ==========
    public void PickCharacter(int index)
    {
        if (index < 0 || index >= characters.Length) return;
        currentCharIndex = index;

        var spec = characters[index];
        if (portraitImage) portraitImage.sprite = spec.portrait;
        if (nameText) nameText.text = spec.displayName;
    }

    public void OnClickConfirmCharacter()
    {
        if (currentCharIndex < 0) return;

        var spec = characters[currentCharIndex];
        GameSession.I.SetCharacter(spec);

        var map = maps[Random.Range(0, maps.Length)];
        GameSession.I.SetMap(map);

        SceneManager.LoadScene(map.sceneName);
    }
    public void OnClickBack()
    {
        characterPanel.SetActive(false);

        mainPanel.SetActive(true);
    }
}
