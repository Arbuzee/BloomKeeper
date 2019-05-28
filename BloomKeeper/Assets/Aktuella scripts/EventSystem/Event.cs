﻿using System;
using UnityEngine;

namespace EventCallbacks
{
    public abstract class Event<T> where T : Event<T> {
        public string Description;

        private bool hasFired;
        public delegate void EventListener(T info);
        private static event EventListener listeners;
        
        public static void RegisterListener(EventListener listener) {
            listeners += listener;
        }

        public static void UnregisterListener(EventListener listener) {
            listeners -= listener;
        }

        public void FireEvent() {
            if (hasFired) {
                throw new Exception("This event has already fired, to prevent infinite loops you can't refire an event");
            }
            hasFired = true;
            if (listeners != null) {
                listeners(this as T);
            }
        }
    }

    //public class DebugEvent : Event<DebugEvent>
    //{
    //    public int VerbosityLevel;
    //}

    public class UnitDeathEvent : Event<UnitDeathEvent>
    {
        public GameObject UnitGO;
        /*

        Info about cause of death, our killer, etc...

        Could be a struct, readonly, etc...

        */
    }

    public class SoundEvent : Event<SoundEvent>
    {
        public AudioClip sound;

    }

    public class ParticleEvent : Event<ParticleEvent>
    {
        public ParticleSystem particles;
    }

    public class TutorialMovementEvent : Event<TutorialMovementEvent>
    {
        public GameObject toBeSetActive;
    }

    public class DecoyDestroyEvent : Event<DecoyDestroyEvent>
    {
        
    }
}