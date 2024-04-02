using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
[CreateAssetMenu(fileName = "WheelDataContainer", menuName = "SpinWheel/WheelDataContainer")]
public class WheelDataContainer : ScriptableObject{

    [SerializeField] private SpinWheelAttribute data;
    public string fileName ;

    public SpinWheelAttribute Data { get => data; set => data = value; }

    [Button]
    void LoadData()
    {
        TextAsset file = Resources.Load<TextAsset>(fileName);
        if (file != null)
        {
            Data = JsonUtility.FromJson<SpinWheelAttribute>(file.text) as SpinWheelAttribute;
            if (Data != null)
            {
                
                Debug.Log("Loaded coins: " + Data.coins);
           }
            else
            {
                Debug.LogError("Failed to parse JSON into RewardData.");
            }
        }
        else
        {
            Debug.LogError("Failed to load JSON file.");
        }

       
    }
    // Start is called before the first frame update

}

[Serializable]
public class SpinWheelAttribute
{
    public int coins;
    public List<WheelTileData> rewards = new List<WheelTileData>();

}
[Serializable]
public class WheelTileData
{
    public float multiplier;
    public float probability;
    public string color;
}
