using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelChooseButton : MonoBehaviour
{
    public int levelNumber;
    public Image[] stars;
    private bool isCanInteract;
    private void Start()
    {
        InitButton();
    }
    private void InitButton()
    {
        if (PlayerPrefs.HasKey("LevelDone"+(levelNumber).ToString()))
        {
            isCanInteract = true;
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
        SetStars(PlayerPrefs.GetInt("Level"+levelNumber.ToString()));
    }
    public void SetStars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            stars[i].color = Color.yellow;
        }
        for (int i = count;i<stars.Length;i++)
        {
            stars[i].color = Color.grey;
        }
    }
}
