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
{
    //Panel de opciones
    public GameObject optionsPanel;
    //Array para poner los 3 valores RGB
    public TMP_InputField[] RGB;
    //Imagen el player
    public Image preview;

    void Start()
    {
        //Hacemos que los opciones no se vean al principio
        optionsPanel.SetActive(false);
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
    public bool IsValidRGB()
    {
        //Comprobamos que el valor introducido por el usuario sea valido
        foreach (var t in RGB)
        {
            Debug.Log(t.text.GetType());
            int.TryParse(t.text, out int val);
            if (!ValueBetween(val, 0, 255))
            {
                return false;
            }
        }
        return true;
    }
    public void ApplyRGBColor()
    {
        //Cambiamos el color del player al introducio por el usuario
        if (IsValidRGB())
        {
            preview.color = new Color(NormalizeValue(RGB[0].text, 255f),
                NormalizeValue(RGB[1].text, 255f),
                NormalizeValue(RGB[2].text, 255f));
        }
    }
    private float NormalizeValue(string s, float max)
    {
        int val = int.Parse(s);
        return val / max;
    }

    private bool ValueBetween(int val, int min, int max)
    {
        if (val >= min && val <= max)
        {
            return true;
        }

        return false;

    }
}
