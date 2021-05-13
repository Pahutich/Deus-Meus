using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int tileX;
    public int tileY;
    public bool isWalkable = true;
    private Text coordsText;

    void Start()
    {
        coordsText = GetComponentInChildren<Text>();
        coordsText.text = (tileX.ToString() + "," + tileY.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
