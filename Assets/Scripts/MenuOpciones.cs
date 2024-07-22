using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        
        LoadSettings();
    }

    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
        
        PlayerPrefs.SetInt("PantallaCompleta", pantallaCompleta ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
        
        PlayerPrefs.SetFloat("Volumen", volumen);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
       
        if (PlayerPrefs.HasKey("PantallaCompleta"))
        {
            bool pantallaCompleta = PlayerPrefs.GetInt("PantallaCompleta") == 1;
            Screen.fullScreen = pantallaCompleta;
        }

        
        if (PlayerPrefs.HasKey("Volumen"))
        {
            float volumen = PlayerPrefs.GetFloat("Volumen");
            audioMixer.SetFloat("Volumen", volumen);
        }
    }
}
