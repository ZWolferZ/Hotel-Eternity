using UnityEngine;
using UnityEngine.Serialization;

public class PlayerWeight : MonoBehaviour
{
    // Initialising variables
    public int weight;
    public float trueWeight;
    [FormerlySerializedAs("CarryWeight")] public TMPro.TextMeshProUGUI carryWeight;

    // Initialising text
    private void Start()
    {
        carryWeight.text = "Carry Weight: " + weight;
    }

    private void Update()
    {
        // Switch expression for weight conversion
        trueWeight = weight switch
        {
            0 => 10,
            1 => 20,
            2 => 30,
            3 => 40,
            4 => 50,
            5 => 60,
            6 => 70,
            7 => 80,
            8 => 90,
            9 => 100,
            10 => 110,
            11 => 120,
            12 => 130,
            13 => 140,
            14 => 150,
            15 => 160,
            16 => 170,
            17 => 180,
            18 => 190,
            19 => 200,
            _ => trueWeight
        };
    }

}
