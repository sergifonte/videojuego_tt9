using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialUIController : MonoBehaviour
{
    [Header("Cartells de la UI")]
    [SerializeField] private GameObject textPremerE;
    [SerializeField] private GameObject textBotoAbans;
    [SerializeField] private GameObject textMesGran;

    [Header("Configuració")]
    [SerializeField] private string nomNivell1 = "Nivel1"; // Nom de l'escena del primer nivell

    private bool botoPremut = false;
    private bool dinsZonaBoto = false;

    void Start()
    {
        // Ens assegurem que tot comença net i apagat
        if (textPremerE != null) textPremerE.SetActive(false);
        if (textBotoAbans != null) textBotoAbans.SetActive(false);
        if (textMesGran != null) textMesGran.SetActive(false);
    }

    void Update()
    {
        // Si el jugador està al botó i prem la E...
        if (dinsZonaBoto && !botoPremut && Input.GetKeyDown(KeyCode.E))
        {
            // Comprovem si és Gran (index == 0 segons el script de l'Emma)
            if (Instance.instance != null && Instance.instance.index == 0)
            {
                botoPremut = true;
                if (textMesGran != null) textMesGran.SetActive(false);
                Debug.Log("Botó activat amb èxit!");
            }
            else
            {
                // Si no és gran, li recordem que s'ha de fer gran
                if (textMesGran != null) textMesGran.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 1. S'apropa a la gota de cera
        if (other.CompareTag("WaxBall"))
        {
            if (textPremerE != null) textPremerE.SetActive(true);
        }

        // 2. S'apropa al botó
        if (other.CompareTag("Button") && !botoPremut)
        {
            dinsZonaBoto = true;
            // Alerta immediata si s'apropa i no té la mida adequada
            if (Instance.instance != null && Instance.instance.index != 0)
            {
                if (textMesGran != null) textMesGran.SetActive(true);
            }
        }

        // 3. Arriba a la porta de sortida
        if (other.CompareTag("Porta"))
        {
            if (botoPremut)
            {
                SceneManager.LoadScene(nomNivell1); // Teletransport
            }
            else
            {
                if (textBotoAbans != null) textBotoAbans.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Netegem els textos en sortir de les zones
        if (other.CompareTag("WaxBall"))
        {
            if (textPremerE != null) textPremerE.SetActive(false);
        }

        if (other.CompareTag("Button"))
        {
            dinsZonaBoto = false;
            if (textMesGran != null) textMesGran.SetActive(false);
        }

        if (other.CompareTag("Porta"))
        {
            if (textBotoAbans != null) textBotoAbans.SetActive(false);
        }
    }
}