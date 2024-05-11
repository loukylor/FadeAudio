using UnityEngine;

namespace Audio
{
    public class FadeAudio : MonoBehaviour
    {
        public bool fadeOnAudioEnd = true;
        public bool fadeOnAudioStart = true;
        public float fadeTime;

        public float minVolume = 0;
        public float maxVolume = 1;

        public AudioSource source;

        public void Play()
        {
            source.volume = minVolume;
            source.Play();
        }

        private void Update()
        {
            if (source == null || source.clip == null || source.clip.length == 0)
            {
                return;
            }

            // Fade at the beginning
            if (fadeOnAudioStart && source.time < fadeTime)
            {
                // Smoothly increase volume
                source.volume = Mathf.Lerp(minVolume, maxVolume, source.time / fadeTime);
            }
            // Fade at the end
            else if (fadeOnAudioEnd && source.clip.length - source.time < fadeTime)
            {
                // Smoothly decrease volume
                source.volume = Mathf.Lerp(minVolume, maxVolume, (source.clip.length - source.time) / fadeTime);
            }
            else
            {
                // If no fade is needed, keep volume at max
                source.volume = maxVolume;
            }
        }
    }
}