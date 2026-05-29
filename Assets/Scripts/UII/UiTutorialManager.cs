using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialUIController : MonoBehaviour
{
    [Header("Cartells de la UI")]
    [SerializeField] private GameObject textPremerE;
    [SerializeField] private GameObject textBotoAbans;
    [SerializeField] private GameObject textMesGran;

    [Header("Button")]
    [Tooltip("Arrossega aquí el botó d'aquesta escena concreta")]
    [SerializeField] private ReusableButton botoDeLaPantalla;

    [Header("Configuració de l'Escena")]
    [Tooltip("Índex del Build Settings de la següent escena")]
    [SerializeField] private int buildIndexCinematic = 2;

    private bool buttonZone = false;
    private bool DoorZone = false;

    void Start()
    {
        //setting la escena, s'esborra tot
        if (textPremerE != null) textPremerE.SetActive(false);
        if (textBotoAbans != null) textBotoAbans.SetActive(false);
        if (textMesGran != null) textMesGran.SetActive(false);
    }

    void Update()
    {
        //Amagar text de la gota automàticament si es destrueix
        if (textPremerE != null && textPremerE.activeSelf)
        {
            if (Instance.instance != null && !Instance.instance.isColliding)
            {
                textPremerE.SetActive(false);
            }
        }

        if (buttonZone && botoDeLaPantalla != null)
        {
            if (botoDeLaPantalla.IsPressed)
            {
                if (textMesGran != null) textMesGran.SetActive(false);
                if (DoorZone) CanviarDeNivell();
            }
            // Si intenta interactuar (E) però l'índex no és 0 (no és gran)
            else if (Input.GetKeyDown(KeyCode.E) && Instance.instance != null && Instance.instance.index != 0)
            {
                if (textMesGran != null) textMesGran.SetActive(true);
            }
        }
    }

    private void CanviarDeNivell()
    {
        SceneManager.LoadScene(buildIndexCinematic);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaxBall"))
        {
            if (textPremerE != null) textPremerE.SetActive(true);
        }

        if (other.CompareTag("Button"))
        {
            buttonZone = true;
            // Si encara no està premut i no som grans, avisem
            if (botoDeLaPantalla != null && !botoDeLaPantalla.IsPressed)
            {
                if (Instance.instance != null && Instance.instance.index != 0)
                {
                    if (textMesGran != null) textMesGran.SetActive(true);
                }
            }
        }

        if (other.CompareTag("Porta"))
        {
            DoorZone = true;
            if (botoDeLaPantalla != null && botoDeLaPantalla.IsPressed)
            {
                CanviarDeNivell();
            }
            else
            {
                if (textBotoAbans != null) textBotoAbans.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WaxBall"))
        {
            if (textPremerE != null) textPremerE.SetActive(false);
        }

        if (other.CompareTag("Button"))
        {
            buttonZone = false;
            if (textMesGran != null) textMesGran.SetActive(false);
        }

        if (other.CompareTag("Porta"))
        {
            DoorZone = false;
            if (textBotoAbans != null) textBotoAbans.SetActive(false);
        }
    }
}