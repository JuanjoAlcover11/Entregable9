using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{//Declaramos las variables
    //Panel de opciones
    public GameObject optionsPanel;
    //Colores olayer
    public GameObject[] colors;
    private int colorSelected;
    //Nombre del player
    public TMP_InputField username;
    //Opcion de modo hardcore
    public Toggle toggle;
    private int HardModeIsOn;

    void Start()
    {
        //Hacemos que los opciones no se vean al principio
        optionsPanel.SetActive(false);
        //Cargamos las opciones del menu
        LoadUserOptions();
    }
    private void Update()
    {
        ColorSelection();
    }
    public void SaveUserOptions()
    {
        //Persistencia de datos entre escenas
        DataPersistence.sharedInstance.colorSelected = colorSelected;
        DataPersistence.sharedInstance.color = colors[colorSelected].GetComponent<Image>().color;

        DataPersistence.sharedInstance.username = username.text;

        DataPersistence.sharedInstance.HardToggle = HardModeIsOn;

        //Persistencia de datos entre partidas
        DataPersistence.sharedInstance.SaveForFutureGames();
    }
    public void LoadUserOptions()
    {
        //Si tiene esta clave, tiene todas
        if (PlayerPrefs.HasKey("COLOR_SELECTED"))
        {
            colorSelected = PlayerPrefs.GetInt("COLOR_SELECTED");

            username.text = PlayerPrefs.GetString("USERNAME");

            HardModeIsOn = PlayerPrefs.GetInt("HARDMODE");
            HardMode();
        }
    }
    public void OptionsScene()
    {
        //Aparece el panel de opciones al clicar el boton
        optionsPanel.SetActive(true);
    }
    public void OptionsSceneExit()
    {
        //Desaparece el panel de opciones al clicar el boton
        optionsPanel.SetActive(false);
    }
    private void ColorSelection()
    {//Hacemos que se pueda alternar entre colores con las flechas
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            colorSelected++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            colorSelected--;
        }

        colorSelected %= 3;
        ChangeColorSelection();
    }

    private void ChangeColorSelection()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i].transform.GetChild(0).gameObject.SetActive(i == colorSelected);
        }
    }
    //Cambiamos la variable dependiendo de si esta activado el toggle
    public void HardToggle()
    {
        if(toggle.isOn)
        {
            HardModeIsOn = 0;
        }
        else
        {
            HardModeIsOn = 1;
        }
    }
    public void HardMode()
    {
        if (HardModeIsOn == 0)
        {
            toggle.isOn = true;
        }

        else
        {
            toggle.isOn = false;
        }
    }
}
