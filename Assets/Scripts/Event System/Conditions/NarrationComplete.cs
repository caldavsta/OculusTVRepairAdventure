using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Event_System.Conditions
{
    public class NarrationComplete : Condition
    {
        private AudioSource _narrationAudioSource;
        public bool SetComplete()
        {
            SetNarrationAudioSource();

            if (_narrationAudioSource.isPlaying)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SetNarrationAudioSource()
        {
            if (_narrationAudioSource == null)
            {
                _narrationAudioSource = GameObject.Find(EventManager.NAME).GetComponent<AudioSource>();
                if (_narrationAudioSource == null)
                {
                    Debug.LogError("NarrationComplete : Condition || Cant find narration audio souce");
                }
            }
        }
    }
}
