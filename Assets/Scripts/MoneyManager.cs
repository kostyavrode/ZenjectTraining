using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MoneyManager : MonoBehaviour
{
    public TMP_Text moneyText;
    public GameObject buy1Button;
    public GameObject buy2Button;
    public void OnEnable()
    {
        UpdateMoney();
        CheckBuy();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 100);
            UpdateMoney();
        }
    }
    public void UpdateMoney()
    {
        moneyText.text = PlayerPrefs.GetInt("Money").ToString();
    }
    public void Buy1()
    {
        if (PlayerPrefs.GetInt("Money")>=100)
        {
            PlayerPrefs.SetString("Buy1", "d");
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money")-100);
            PlayerPrefs.Save();
            buy1Button.SetActive(false);
            UpdateMoney();
        }
    }
    public void Buy2()
    {
        if (PlayerPrefs.GetInt("Money") >= 300)
        {
            PlayerPrefs.SetString("Buy2", "d");
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 300);
            PlayerPrefs.Save();
            buy2Button.SetActive(false);
            UpdateMoney();
        }
    }
    private void CheckBuy()
    {
        if (PlayerPrefs.HasKey("Buy1"))
        {
            buy1Button.SetActive(false);
        }
    }
}
