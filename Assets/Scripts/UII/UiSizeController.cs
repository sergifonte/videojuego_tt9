using UnityEngine;

public class SizeUIController : MonoBehaviour
{
    [Header("Instruccions UI")]
    [SerializeField] private GameObject smallSizeUI;
    [SerializeField] private GameObject mediumSizeUI;
    [SerializeField] private GameObject bigSizeUI;

    private int lastIndex = -1;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (Instance.instance != null) //script de l'instancia ha de carregar correctament abans
        {
            // Si el valor del seu index ha canviat des de l'últim fotograma, actualitzem la UI
            if (Instance.instance.index != lastIndex)
            {
                UpdateUI();
            }
        }
    }

    private void UpdateUI()
    {
        if (Instance.instance == null) return;

        // Actualitzem quin és l'índex actual que estem processant
        lastIndex = Instance.instance.index;

        //destiva tota la UI predeterminat
        smallSizeUI.SetActive(false);
        mediumSizeUI.SetActive(false);
        bigSizeUI.SetActive(false);

        switch (lastIndex)
        {
            case 0:
                bigSizeUI.SetActive(true);//gran
                break;
            case 1:
                mediumSizeUI.SetActive(true);//mig
                break;
            case 2:
                smallSizeUI.SetActive(true);//petit
                break;
        }
    }
}