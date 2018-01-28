using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropdownSfx : MonoBehaviour
{
    public Dropdown resDropdown;
    public AudioSource activate;

    public void OnPointerClick(PointerEventData ped)
    {
        activate.PlayOneShot(activate.clip);
    }
}
