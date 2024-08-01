using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelChooseButton : MonoBehaviour
{
    public int levelNumber;
    public Image[] stars;
    private bool isCanInteract;
    private void OnEnable()
    {
        InitButton();
    }
    private void InitButton()
    {
        if (PlayerPrefs.HasKey("LevelDone"+(levelNumber)) || PlayerPrefs.HasKey("LevelDone" + (levelNumber-1)))
        {
            isCanInteract = true;
            GetComponent<Button>().interactable = true;
        }
        else if (levelNumber==0)
        {
            isCanInteract = true;
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
        SetStars(PlayerPrefs.GetInt("LevelDone"+levelNumber.ToString()));
        Debug.Log(PlayerPrefs.GetInt("LevelDone" + levelNumber.ToString()));
    }
    public void SetStars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            stars[i].color = Color.white;
        }
        for (int i = count;i<stars.Length;i++)
        {
            stars[i].color = Color.grey;
        }
    }
}
