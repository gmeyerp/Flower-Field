using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject victoryScreen; // Referência ao objeto da tela de vitória
    public AudioClip victorySound; // Clipe de áudio para a vitória
    private AudioSource audioSource; // Componente AudioSource para tocar o áudio

    void Start()
    {
        // Certifique-se de que o objeto da tela de vitória está desativado inicialmente
        if (victoryScreen != null)
            victoryScreen.SetActive(false);

        // Configura o AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Adiciona um AudioSource se não existir um no GameObject
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica se é o jogador que colidiu
        if (other.CompareTag("Player"))
        {
            // Ativa a tela de vitória
            if (victoryScreen != null)
                victoryScreen.SetActive(true);

            // Toca o som de vitória
            if (victorySound != null && audioSource != null)
            {
                audioSource.clip = victorySound;
                audioSource.Play();
            }
        }
    }
}
