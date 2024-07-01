using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public  void    PressStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public  void    BackToMenu()
    {
        SceneManager.LoadScene("Start"); 
    }

	public  void    PressCredits()
	{
		SceneManager.LoadScene("Credits"); 
	}

	public  void    Exit()
	{
		Application.Quit();
	}
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
