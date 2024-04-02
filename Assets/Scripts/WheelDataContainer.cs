using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
[CreateAssetMenu(fileName = "WheelDataContainer", menuName = "SpinWheel/WheelDataContainer")]
public class WheelDataContainer : ScriptableObject{

    [SerializeField] private SpinWheelAttribute data;
    public string fileName ;

    [Button]
    void LoadData()
    {
        TextAsset file = Resources.Load<TextAsset>(fileName);
        if (file != null)
        {
            data = JsonUtility.FromJson<SpinWheelAttribute>(file.text) as SpinWheelAttribute;
            if (data != null)
            {
                
                Debug.Log("Loaded coins: " + data.coins);
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
