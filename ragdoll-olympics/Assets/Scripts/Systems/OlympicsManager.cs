using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OlympicsManager : MonoBehaviour
{
    public static OlympicsManager main;

    public OlympicEvent firstEvent;
    public List<Data.Player> playerData;
    public int maxRounds = 5;

    private System.Random random = new System.Random();
    private string currentMap;
    private OlympicEvent currentEvent;
    private int currentRound = 0;

    // Start is called before the first frame update
    void Start() {
        OlympicsManager.main = this;
        this.LoadEvent(firstEvent);
    }

    // Loads an event map
    public void LoadMap(string mapName) {

        this.LoadLoadingScreen(); // Show loading screen

        // Does a single mode load of the map scene
        AsyncOperation op = SceneManager.LoadSceneAsync(mapName, LoadSceneMode.Additive);
        op.completed += this.UnloadLoadingScreen; // Unloads loading screen on map load
        op.completed += this.LoadGui; // Load GUI on complete
        op.completed += this.IntializePlayers; // Place players in world
        
        // Saves the name of the current map
        currentMap = mapName;
    }

    private void LoadGui(AsyncOperation op = null) {
        SceneManager.LoadScene(currentEvent.eventUiScene, LoadSceneMode.Additive);
    }

    private void UnloadGui() {
        SceneManager.UnloadSceneAsync(currentEvent.eventUiScene);
    }

    private void LoadLoadingScreen() {
        SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);
    }

    private void UnloadLoadingScreen(AsyncOperation op = null) {
        SceneManager.UnloadSceneAsync("LoadingScreen");
    }

    // Unloads the current map
    public void UnloadMap() {
        UnloadGui();
        if (currentMap != null) {
            SceneManager.UnloadSceneAsync(currentMap);
            currentMap = null;
        } else {
            Debug.LogWarning("Tried to unload a map when 'currentMap' is null!");
        }
    }

    public void IntializePlayers(AsyncOperation op = null) {

        // Set gamemap as the active scene (for spawning)
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentMap));

        // Lookup spawn points
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("IntialSpawnPoint");
        
        for (int i = 0; i < playerData.Count; i++) // For each player
        {
            // Create player object
            GameObject pObj = Instantiate(currentEvent.playerPrefab);
            pObj.name = string.Format("Player: {0}", playerData[i].playerName);

            // Determine valid spawn location
            if (spawns.Length >= 1) {
                GameObject spawn;
                if (i < spawns.Length)
                {
                    spawn = spawns[i];
                }
                else {
                    Debug.LogWarning("Not enough spawns are set for the current map!");
                    spawn = spawns[random.Next(spawns.Length)];
                }
                pObj.transform.position = spawn.transform.position;
            } else {
                Debug.LogWarning("No spawns are set for the current map!");
            }
        }

    }

    // Selects a new map from event and loads it
    public void LoadEvent(OlympicEvent e) {

        currentRound++; // Increment round on new event

        currentEvent = e;

        // Randomly select next map
        string nextMap = e.eventMaps[random.Next(e.eventMaps.Count)];

        this.LoadMap(nextMap);
    }

    public void FinishEvent(string first, string second, string third) {
        
        // Update scores based upon placing
        for (int i = 0; i < playerData.Count; i++)
        {
            if (playerData[i].playerName == first) { // First gold
                playerData[i].goldMedals++;
            } else if (playerData[i].playerName == second) { // Second silver
                playerData[i].silverMedals++;
            } else if (playerData[i].playerName == third) { // Third bronze
                playerData[i].bronzeMedals++;
            } else {
                playerData[i].participationMedals++; // Fourth, you tried
            }
        }

        this.UnloadMap();

        if (currentRound < maxRounds) {
            // For now just reload same event
            this.LoadEvent(firstEvent);
        } else {
            // For now just exit to main menu on completion
            // in the future, we can change this to a score screen
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

    }
}
