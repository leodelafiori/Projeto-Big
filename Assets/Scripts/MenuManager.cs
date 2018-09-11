using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// MenuManager
/// Menu manager é utilizado para gerenciar os menus do "World Map"
/// Por: Leonardo Delafiori

public class MenuManager : MonoBehaviour {

    #region Declaring Variables
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject buttonsMenu;
    [SerializeField] private GameObject configMenu;
    #endregion

    #region Funções para botões
    public void entraMenu()
    {
        buttonsMenu.SetActive(false);
        menu.SetActive(true);
        Time.timeScale = 0;
    }
    public void saiMenu()
    {
        buttonsMenu.SetActive(true);
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void exit()
    {
        Application.Quit();
    }
    #endregion


}
