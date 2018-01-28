using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler {
    public AudioSource audioSource;
	
	public void OnPointerEnter (PointerEventData ped) {
        audioSource.PlayOneShot(audioSource.clip);
	}
}
