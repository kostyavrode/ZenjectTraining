using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    [SerializeField] private TileManager[] tileManagers;
    [SerializeField] private GameObject levelPassedPanel;
    public Image timeBar;
    public TMP_Text gameTimeBar;
    public TMP_Text scoreBar;
    public TMP_Text accordanceBar;
    private TileManager manager;
    public void InitLevel(int level)
    {
       manager=Instantiate(tileManagers[level]);
        manager.OnInit(this);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LevelPassed()
    {
        Destroy(manager);
        levelPassedPanel.SetActive(true);
    }
    public void StopGame()
    {
        Destroy(manager);
    }
}
