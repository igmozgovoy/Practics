using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private bool _isActiveated = false;

    public void Activate()
    {
        _isActiveated = true;
    }
    public void FinishLevel()
    {
        if (_isActiveated)
            gameObject.SetActive(false);
    }
}
