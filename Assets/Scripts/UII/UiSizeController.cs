using UnityEngine;

public class SizeUIController : MonoBehaviour
{
    [Header("Imatges de la UI")]
    [SerializeField] private GameObject smallSizeUI;
    [SerializeField] private GameObject mediumSizeUI;
    [SerializeField] private GameObject bigSizeUI;

    // Guardem l'últim índex detectat per no estar activant/desactivant GameObjects inútilment
    private int ultimIndexDetectat = -1;

    void Start()
    {
        // Forcem l'actualització inicial de la UI en arrencar
        ActualitzarInterficie();
    }

    void Update()
    {
        // Si el script de l'Emma ja està llest a l'escena
        if (Instance.instance != null)
        {
            // Si el valor del seu index ha canviat des de l'últim fotograma, actualitzem la UI
            if (Instance.instance.index != ultimIndexDetectat)
            {
                ActualitzarInterficie();
            }
        }
    }

    private void ActualitzarInterficie()
    {
        // Si encara no s'ha creat la instància global (per seguretat), no fem res
        if (Instance.instance == null) return;

        // Actualitzem quin és l'índex actual que estem processant
        ultimIndexDetectat = Instance.instance.index;

        // Desactivem totes les imatges primer per "netejar" la UI
        smallSizeUI.SetActive(false);
        mediumSizeUI.SetActive(false);
        bigSizeUI.SetActive(false);

        // Activem només la que correspon segons el switch de l'Emma
        switch (ultimIndexDetectat)
        {
            case 0:
                bigSizeUI.SetActive(true);    // Mostra Mida Gran
                break;
            case 1:
                mediumSizeUI.SetActive(true); // Mostra Mida Mitjana
                break;
            case 2:
                smallSizeUI.SetActive(true);  // Mostra Mida Petita
                break;
        }
    }
}