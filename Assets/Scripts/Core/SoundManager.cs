using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource source;

    private void Awake() {
        source = GetComponent<AudioSource>();

    }
}
