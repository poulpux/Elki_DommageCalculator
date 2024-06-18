using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XPManager : MonoSingleton<XPManager> 
{
    public UnityEvent<string> gainXpEvent = new UnityEvent<string>();
}

[Serializable]
public class CharacterXP
{
    public string name;
    public int nbLv, nbXpToNextLv;

    public void CalculateXPAndLV()
    {
        int totalXP = PlayerPrefs.GetInt(name);

        //Faire le calcul pour completer les variables
        nbLv = totalXP;
    }
}