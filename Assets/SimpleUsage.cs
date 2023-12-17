using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BayatGames.SaveGameFree;

public class SimpleUsage : MonoBehaviour {

    public int score;

    void Start () {

        // Saving the data
        SaveGame.Save<int> ( "score", score );
    }

}