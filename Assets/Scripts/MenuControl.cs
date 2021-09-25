using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    #region Initialization
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion

    #region Play Button Methods
    public void PlayGame()
    {
        SceneManager.LoadScene("InGame");
    }
    #endregion

    #region General Application Button Methods
    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
