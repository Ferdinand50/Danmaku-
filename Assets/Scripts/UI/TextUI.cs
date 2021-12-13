using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextUI : MonoBehaviour {
  public Text hpText;
  public Text scoreText;

  // Use this for initialization
  void Start () {
    hpText.text = "HP: " + GlobalVariableStorage.playerHealth;
    scoreText.text = "Score:" + GlobalVariableStorage.score;
  }
  
  // Update is called once per frame
  void Update () {
    hpText.text = "HP: " + GlobalVariableStorage.playerHealth;
    scoreText.text = "Score: " + GlobalVariableStorage.score;
  }

  
}