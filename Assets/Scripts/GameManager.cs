using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public MeshRenderer player;
    public TextMeshProUGUI username;
    public bool HardModeIsOn;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        // Aplicamos los cambios guardados en la escena Menu
        ApplyUserOptions();
    }

    public void ApplyUserOptions()
    {
        player.material.color = DataPersistence.sharedInstance.color;
        username.text = DataPersistence.sharedInstance.username;
       // HardModeIsOn.text = DataPersistence.sharedInstance.HardModeIsOn;
    }
}
