using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    private int scoreAmount = 0;
    private int tempScoreAmount = 0;
    private TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreAmount = GameManager.instance.saveData.playerData.score;
        tempScoreAmount = GameManager.instance.saveData.playerData.tempScore;
        _text.SetText("Score:  " + (scoreAmount + tempScoreAmount).ToString());
    }
}
