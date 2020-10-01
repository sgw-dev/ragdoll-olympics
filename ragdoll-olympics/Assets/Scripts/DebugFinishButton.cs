using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugFinishButton : MonoBehaviour
{
    public void FinishRound() {
        OlympicsManager.main.FinishEvent("nobody","nothing","zero");
    }
}
