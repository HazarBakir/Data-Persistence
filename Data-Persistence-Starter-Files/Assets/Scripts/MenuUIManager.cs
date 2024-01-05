using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager Instance;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI HiScoreText;
    public int HiScore;
    public string PlayerName;
    public string LastPlayerName;
    private void Start()
    {
        SavePlayerData playerData = new SavePlayerData();
        LoadData();
        HiScoreText.text = $"Hi Score : {LastPlayerName} : {HiScore}";
    }
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    public class SavePlayerData
    {
        public int HiScore;
        public string PlayerName;
        public string LastPlayerName;
    }
    public void StartGame()
    {
        SaveData();
        SceneManager.LoadScene("main");
    }
    public void SaveData()
    {
        SavePlayerData playerData = new SavePlayerData();
        PlayerName = NameText.text;
        playerData.PlayerName = PlayerName;
        playerData.HiScore = HiScore;
        playerData.LastPlayerName = LastPlayerName;

        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavePlayerData playerData = JsonUtility.FromJson<SavePlayerData>(json);
            PlayerName = playerData.PlayerName;
            HiScore = playerData.HiScore;
            LastPlayerName = playerData.LastPlayerName;
        }
    }

}
