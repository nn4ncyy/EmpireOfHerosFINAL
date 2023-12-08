using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;

    public void Interact()
    {
        DialogManager.Instance.ShowDialog(dialog);
        //Debug.Log("building");
    }
}
