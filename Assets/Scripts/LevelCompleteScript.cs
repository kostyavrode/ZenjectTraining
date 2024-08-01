using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCompleteScript : MonoBehaviour
{
    public TMP_Text inGameScore;
    public TMP_Text inGameAccordance;
    public TMP_Text completeScore;
    public TMP_Text completeAccordance;
    public TMP_Text loseScore;
    public TMP_Text loseAccordance;
    private void OnEnable()
    {
        completeScore.text= inGameScore.text;
        loseScore.text= inGameScore.text;
        completeAccordance.text= inGameAccordance.text;
        loseAccordance.text = inGameAccordance.text;
    }
}
