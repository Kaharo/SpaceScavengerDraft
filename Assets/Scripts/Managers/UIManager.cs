using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject textObj;

    public void Start()
    {
        SetActive(false);
    }

    public void SetActive(bool state)
    {
        textObj.SetActive(state);
    }
}
