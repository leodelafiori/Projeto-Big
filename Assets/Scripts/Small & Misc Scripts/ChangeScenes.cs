using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScenes : MonoBehaviour {

    
    /// Script simples com apenas um método para mudança de menus, usado por botões para gerenciar as cenas no game
    /// por: Leonardo Delafiori
  
	public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
