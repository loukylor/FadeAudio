# FadeAudio

## Description

This mechanic shows how to fade in and out background audio at the beginning
or end of the audio.

## Implementation

The code itself is straightforward:
```cs
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
```

To set it up:
 - Ensure there is an `AudioListener` component on your main camera.
 - Add an `AudioSource` component and assign an audio clip.
 - Optionally, click the `Loop` option to on if you want the audio to loop.
 - Add a `FadeAudio` component and assign the `source` property to the 
 audio source you just created. 
 - Change the `Fade Time` property to however long you want the audio to fade 
 in/out for.

## Example Project

It can be viewed [here](https://loukylor.github.io/FadeAudio/)

There are no enemies or controls. The text displays the amount into the audio
clip the source currently is, and the volume of the source. The slider lets the
user seek to any part of the audio, so that the fade in and out can more easily
be heard.

## Challenges

This wasn't particularly challenging, especially because I've implemented
similar systems in other games. It took about an hour, although I spent another
hour figuring out what to do for this assignment.

## Credits

The audio was pulled from a previous project and written by David Zeng, although
it is licensed under MIT, so this is technically unecessary to include.