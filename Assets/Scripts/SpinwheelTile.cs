using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class SpinwheelTile : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI multipliertext;
    [SerializeField] private Image BgImage;
    [SerializeField]private float multiplier;
    [SerializeField] private float probability;
    [SerializeField] private float angleinWheel ;
    [SerializeField] public int TotalCoins;
    // Start is called before the first frame update

    public Func<int> TotalUpdatedCoins_Func;
    public Func<float> tileangle_func;
    void Start()
    {
        TotalUpdatedCoins_Func += TotalUpdatedCoins;
        tileangle_func += ()=> angleinWheel;
    }

    public void SetPropertiesofTile(float _multiplier,float _probability,string _color,float _angle)
    {
      multiplier=_multiplier;
         probability=_probability;
        TileColor(_color);
        angleinWheel = _angle;
        multipliertext.text = multiplier.ToString();
    }

    int TotalUpdatedCoins()
    {
        return (int)multiplier * TotalCoins;
    } 
    public void TileColor(string color)
    {
        Color tileColor;
        ColorUtility.TryParseHtmlString(color, out tileColor);
       BgImage.material.color = Color.white;
        BgImage.color = tileColor;
    }
}
