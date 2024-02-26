using UnityEngine;
using Random = UnityEngine.Random;

public class RandomLootSpawns : MonoBehaviour
{
  [SerializeField] private GameObject[] loot;

  private void Awake()
  {
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
