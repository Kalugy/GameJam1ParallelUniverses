using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroImageSequencer : MonoBehaviour
{
    [Tooltip("Drag your UI Image components here in order")]
    public Image[] panels;       // Assign your 3 Image components in the Inspector

    [Tooltip("Clip to play when each panel appears (one per panel)")]
    public AudioClip[] audioClips; // Assign one clip per panel in the same order

    [Tooltip("Drag an AudioSource here (or add one on this GameObject)")]
    public AudioSource audioSource;

    [Tooltip("Drag your “Next” Button here")]

    public UnityEngine.UI.Button nextButton;

    private int currentIndex = 0;

    void Start()
    {
        // Safety checks
        if (panels == null || panels.Length == 0)
            Debug.LogError("No panels assigned!");
        if (audioClips == null || audioClips.Length != panels.Length)
            Debug.LogWarning("Number of audio clips does not match number of panels.");

        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        // Hide all except the first
        for (int i = 0; i < panels.Length; i++)
            panels[i].gameObject.SetActive(i == currentIndex);

        // Play first clip
        PlayClipForIndex(currentIndex);

        // Hook up button
        nextButton.onClick.AddListener(ShowNextPanel);
    }

    void Update()
    {
        // listen for click, Enter or Space
        if (currentIndex < panels.Length &&
            (Input.GetKeyDown(KeyCode.Return) ||
             Input.GetKeyDown(KeyCode.Space)))
        {
            ShowNextPanel();
        }
    }

    void ShowNextPanel()
    {
        // hide current panel
        if (currentIndex < panels.Length)
            panels[currentIndex].gameObject.SetActive(false);

        currentIndex++;

        if (currentIndex < panels.Length)
        {
            // show next
            panels[currentIndex].gameObject.SetActive(true);
            PlayClipForIndex(currentIndex);
        }
        else
        {
            // done
            nextButton.gameObject.SetActive(false);
            BeginGame();
        }
    }

    void PlayClipForIndex(int index)
    {
        if (audioClips != null && index < audioClips.Length && audioClips[index] != null)
        {
            audioSource.Stop();
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
    }

    void BeginGame()
    {
        Debug.Log("All intro images shown → starting gameplay!");
        SceneManager.LoadScene("GameLvl1");
    }
}