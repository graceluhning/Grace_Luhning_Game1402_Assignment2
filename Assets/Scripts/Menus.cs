using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
  
  public GameObject pauseUI;
  public GameObject gameOverUI;
  public GameObject gameWonUI;
  
  private bool _isPaused = false;

  void Start() // on start
  {
    Time.timeScale = 1f;
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
    _isPaused = false;
    
    pauseUI.SetActive(false);
    gameOverUI.SetActive(false);
    gameWonUI.SetActive(false);

  }
  public void PlayGame() // when play game button pressed, start game
  {
    SceneManager.LoadScene("MainGame");
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }

  public void QuitGame() // quit game
  {
    Application.Quit();
  }
  
  void Update() 
  {
    if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "MainGame") // pause logic
    {
      if (_isPaused)
      {
        ResumeGame();
      }

      else
      {
        PauseGame();
      }
    }
  }
  
  public void PauseGame() // open pause ui, set timescale, and open cursor on pause
  {
    
      pauseUI.SetActive(true);
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
      
      Time.timeScale = 0f;
        _isPaused = true;
    
  }
  
  public void ResumeGame() // close pause UI and lock cursor
  {
    
      pauseUI.SetActive(false);
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
      
      Time.timeScale = 1f;
      _isPaused = false;
    
  }
  
  public void GameOver() // open game over UI function
  {
    
    gameOverUI.SetActive(true); // open game over
    Cursor.visible = true; // turn on cursor
    Cursor.lockState = CursorLockMode.None;
      
    Time.timeScale = 0f;
    
  }

  public void GameWon() // Game won functions
  {
    gameWonUI.SetActive(true); // open game won 
    Cursor.visible = true; // turn on cursor
    Cursor.lockState = CursorLockMode.None;
      
    Time.timeScale = 0f;
  }
  
  public void PlayAgainButton() // Play again button function
  {
    SceneManager.LoadScene("MainGame");
        
  }
  
}
