using System;
using System.Collections.Generic;
using UnityEngine;

public static class YieldInstructionCache {
    private static Dictionary<float, WaitForSeconds> waitForSecondDictionary = new Dictionary<float, WaitForSeconds>(); 
    private static object waitUntil = null;

    public static object WaitUntil => waitUntil;

    public static WaitForSeconds WaitingSeconds(float waitingTime){
        if(!waitForSecondDictionary.ContainsKey(waitingTime)){
            waitForSecondDictionary.Add(waitingTime, new WaitForSeconds(waitingTime));
        }

        return waitForSecondDictionary[waitingTime];
    }
}