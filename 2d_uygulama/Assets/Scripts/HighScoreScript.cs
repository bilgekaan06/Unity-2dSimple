using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

    public Text score;
    public Text nick;
    public Text rank;
    public void SetScore(string score, string nick, string rank)
    {
        this.rank.text = rank;
        this.nick.text = nick;
        this.score.text = score;
    }

}
