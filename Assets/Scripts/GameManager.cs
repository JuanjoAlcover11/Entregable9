using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{   //Declaramos las variables
    public static GameManager sharedInstance;
    public TextMeshProUGUI HardToggle;
    public MeshRenderer player;
    public TextMeshProUGUI username;
 
    private void Awake()
    {

        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            //Si ya existe una instancia, se destruye
            Destroy(this);
        }
    }
    void Start()
    {
        //Aplicamos las opciones que hemos cambiado en el menu
        ApplyOptions();
    }

    public void ApplyOptions()
    {
        //Data persistance de las opiones
        player.material.color = DataPersistence.sharedInstance.color;
        username.text = DataPersistence.sharedInstance.username;
       // HardToggle.text = DataPersistence.sharedInstance.HardToggle;
        
    }
}
