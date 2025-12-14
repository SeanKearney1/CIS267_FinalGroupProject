using UnityEngine;
using UnityEngine.EventSystems;
public class UI_button_sounds : MonoBehaviour, IPointerEnterHandler
{

    [Header("--Audio Clips--")]
    public AudioClip audio_hover;
    public AudioClip audio_click;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.clip = audio_hover;
        audioSource.Play();
    }

    public void OnClick()
    {
        audioSource.clip = audio_click;
        audioSource.Play();
    }
}
