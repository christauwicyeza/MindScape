using UnityEngine;
using UnityEngine.UI;

public class SoundCont : MonoBehaviour
{
    [System.Serializable]
    public class ToggleAudioPair
    {
        public Toggle toggle;
        public AudioSource audioSource;
    }

    public ToggleAudioPair[] toggleAudioPairs;

    void Start()
    {
        foreach (var pair in toggleAudioPairs)
        {
            if (pair.toggle != null && pair.audioSource != null)
            {
                pair.toggle.isOn = pair.audioSource.isPlaying;
                pair.toggle.onValueChanged.AddListener(isOn => OnToggleChanged(pair.audioSource, isOn));
            }
        }
    }

    void OnToggleChanged(AudioSource audioSource, bool isOn)
    {
        if (audioSource != null)
        {
            if (isOn)
                audioSource.Play();
            else
                audioSource.Stop();
        }
    }

    void OnDestroy()
    {
        foreach (var pair in toggleAudioPairs)
        {
            if (pair.toggle != null)
                pair.toggle.onValueChanged.RemoveAllListeners();
        }
    }
}
