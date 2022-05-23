using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistence : MonoBehaviour

{   //Instancia compartida
    public static DataPersistence sharedInstance;
    //Delaramos Variables. Nos serviran para conservar los valores entre escenas
    public int colorSelected;
    public Color color;
    public string username;
    public int HardToggle;

    private void Awake()
    {
        //Hacemos que si no existe una instancia...
        if (sharedInstance == null)
        {
            sharedInstance = this;
            //...no sea destruida al cambiar la escena
            DontDestroyOnLoad(sharedInstance);
        }
        else
        {
            //Si ya existe una instancia, se destruye
            Destroy(this);
        }
    }
    //Hacemos que se guarden los datos aunque salgamos del juego (para futuras partidas)
    public void SaveForFutureGames()
    {
        //Los tres colores posibles
        PlayerPrefs.SetInt("COLOR_SELECTED", colorSelected);
        PlayerPrefs.SetFloat("R", color[0]);
        PlayerPrefs.SetFloat("G", color[1]);
        PlayerPrefs.SetFloat("B", color[2]);

        //El nombre del player
        PlayerPrefs.SetString("USERNAME", username);

        //Modo hardcore
        PlayerPrefs.SetInt("HARDMODE", HardToggle); ;
    }
}
