using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
 public void PlayLevel1 (){
     Debug.Log("Play Level 1");
     SceneManager.LoadScene("Level1");
 }
}
