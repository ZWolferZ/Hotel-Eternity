using UnityEngine;
using Random = UnityEngine.Random;

public class RandomLootSpawns : MonoBehaviour
{
    // Initialising variable
  [SerializeField] private GameObject[] loot;

  private void Awake()
  {
      // For each item, 50/50 chance it appears or not
      foreach (var instance in loot)
      {
          var random = Random.Range(0, 2);
        
          switch (random)
          {
              case 1:
                  instance.SetActive(true);
                  break;
              case 0:
                  instance.SetActive(false);
                  break;
          }
      }
  }
}
