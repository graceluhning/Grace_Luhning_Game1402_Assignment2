using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
   [SerializeField] private Menus menus;
   
   [SerializeField] TextMeshProUGUI timerText;
   [SerializeField] private float remainingTime;

   void Update()
   {
      if (remainingTime > 0)
      {
         remainingTime -= Time.deltaTime; // how much time is left
      }
      else if (remainingTime <= 0)
      {
         remainingTime = 0;
         menus.GameOver();
      }
      
      int minutes = Mathf.FloorToInt(remainingTime / 60); // minutes
      int seconds = Mathf.FloorToInt(remainingTime % 60); // seconds
      timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
   }
}
