using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int deadCounter;
    
    public PlayerData(GameControl gameControl)
    {
        deadCounter = GameControl.deadCounter;
        
    }

}
