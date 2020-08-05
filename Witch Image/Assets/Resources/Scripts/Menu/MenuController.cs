using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour{
  
    public void OnClickedCharacterPick(int wichCharacter)
    {
        if(PlayerInfo.PI != null)
        {
            PlayerInfo.PI.mySelectedCharacter = wichCharacter;
            PlayerPrefs.SetInt("MyCharacter", wichCharacter);
        }
    }

}
