using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SongProgress : MonoBehaviour
{
    public AudioSource source;
    public Slider slider;
    public TMP_Text text;

    private void Start()
    {
        slider.onValueChanged.AddListener(value =>
        {
            // Only change audio progress if it differs enough from the actual
            // source progress
            if (Mathf.Abs(slider.value - (source.time / source.clip.length)) > 0.01)
            {
                source.time = slider.value * source.clip.length;
            }
        });
    }

    void Update()
    {
        slider.value = source.time / source.clip.length;
        text.text = $"Song progress: {slider.value:n2}\nAudio volume: {source.volume:n2}";
    }
}
