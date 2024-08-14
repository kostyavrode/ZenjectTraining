using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TileManager : MonoBehaviour
{
    public static Action<Tile> onTileSelected;
    public int levelNumber;
    public int gameTime;
    private int score;
    private int accordance;
    private float spendedTime;
    private Image timeBar;
    private TMP_Text gameTimeBar;
    private TMP_Text scoreBar;
    private TMP_Text accordanceBar;
    private GameController gameController;
    [SerializeField] private Tile[] selectedTiles = new Tile[2];
    [SerializeField] private Tile[] allTiles;
    private bool isAllTilesOpened;
    private void Awake()
    {
        onTileSelected += SelectTile;
    }
    private void OnDisable()
    {
        onTileSelected -= SelectTile;
    }
    private void Start()
    {
        FindAllTiles();
    }
    private void Update()
    {

        spendedTime += Time.deltaTime;
        gameTimeBar.text= (gameTime- Math.Round(spendedTime)).ToString();
        timeBar.fillAmount = Mathf.Clamp01((gameTime-spendedTime)/gameTime);
        if (spendedTime > gameTime)
        {
            LevelFailed();
        }
    }
    public void OnInit(GameController gameController)
        {
    this.gameController = gameController;
        if (PlayerPrefs.HasKey("Buy1"))
        {
            gameTime *= 2;
        }
        timeBar=gameController.timeBar;
        gameTimeBar=gameController.gameTimeBar;
        scoreBar=gameController.scoreBar;
        accordanceBar=gameController.accordanceBar;
        accordanceBar.text = "0";
        scoreBar.text= "0";
        }

    public void FindAllTiles()
    {
        allTiles=GetComponentsInChildren<Tile>();
    }
    private void SelectTile(Tile newTile)
    {
        TileArraySwap(newTile);
    }
    private void TileArraySwap(Tile newTile)
    {
        if (selectedTiles[0] == null)
        {
            selectedTiles[0] = newTile;
            return;
        }
        else if (selectedTiles[0] != null && selectedTiles[1] == null)
        {
            selectedTiles[1] = newTile;
        }
        else
        {
            selectedTiles[0] = selectedTiles[1];
            selectedTiles[1] = newTile;
        }

        if (selectedTiles[1] != null)
        {
            CheckTiles();
        }
    }
    private void MergeTile()
    {
        selectedTiles[0].isMerged = true;
        selectedTiles[1].isMerged = true;
        Vector3 difference = Vector3.Lerp(selectedTiles[0].transform.position, selectedTiles[1].transform.position, 0.5f);
        selectedTiles[0].GetComponent<TileAnimator>().AnimateMoveTo(difference, 0.3f);
        selectedTiles[1].GetComponent<TileAnimator>().AnimateMoveTo(difference, 0.3f);
        score+= UnityEngine.Random.Range(5, 10);
        scoreBar.text = (score).ToString();
        accordance += 1;
        accordanceBar.text=accordance.ToString();
        ClearArray();
    }
    private void ClearArray()
    {
        StartCoroutine(WaitForUnSelectTile(selectedTiles[0]));
        StartCoroutine(WaitForUnSelectTile(selectedTiles[1]));
        selectedTiles[0] = null;
        selectedTiles[1] = null;
    }
    private void CheckTiles()
    {
        if (selectedTiles[0].type == selectedTiles[1].type)
        {
            MergeTile();
        }
        else
        {
            ClearArray();
            
        }
        isAllTilesOpened = false;
        foreach (Tile tile in allTiles)
        {
            
            if (!tile.isMerged)
            {
                Debug.Log("TrueCheck");
                return;
            }
        }
        LevelCompleted();
    }
    private void LevelCompleted()
    {
        Debug.Log("level completed");
        if (!PlayerPrefs.HasKey("LevelDone" + levelNumber))
        {
            PlayerPrefs.SetInt("LevelDone" + levelNumber, 3);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 30);
            PlayerPrefs.Save();
        }
        gameController.LevelPassed();
    }
    private void LevelFailed()
    {
        gameController.LevelFailed();
    }
    private IEnumerator WaitForUnSelectTile(Tile tile)
    {
        yield return new WaitForSeconds(0.3f);
        tile.UnSelectTile();
    }
}
