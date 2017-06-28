using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHUDCoords : MonoBehaviour {
    public GameObject GuiText;
    public GameObject PlayerGameObject;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        var x = GuiText.GetComponent<Text>();
        x.text = PlayerGameObject.transform.position.ToString();
    }
}
