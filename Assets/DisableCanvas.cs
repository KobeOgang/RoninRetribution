using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCanvas : MonoBehaviour
{
    public Canvas canvasToDisable;

    void Start()
    {
        // Disable the canvas at the start
        if (canvasToDisable != null)
        {
            canvasToDisable.gameObject.SetActive(false);
        }
    }
}
