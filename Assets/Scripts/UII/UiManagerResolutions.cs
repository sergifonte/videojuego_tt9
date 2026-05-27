using UnityEngine;

public class ControladorResolucio : MonoBehaviour
{
    public void ConfigurarResolucioAlta()
    {
        // Força el canvi a 1920x1080 i el converteix en una finestra flotant
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
        Debug.Log("Forçat a 1920x1080 en mode Finestra");
    }

    public void ConfigurarResolucioMitjana()
    {
        // Finestra flotant més petita
        Screen.SetResolution(1600, 900, FullScreenMode.Windowed);
        Debug.Log("Forçat a 1600x900 en mode Finestra");
    }

    public void ConfigurarResolucioBaixa()
    {
        // Finestra flotant clarament petita per a un monitor gran
        Screen.SetResolution(1366, 768, FullScreenMode.Windowed);
        Debug.Log("Forçat a 1366x768 en mode Finestra");
    }
}