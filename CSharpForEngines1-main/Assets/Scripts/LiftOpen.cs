using System.Collections;
using UnityEngine;

public class LiftOpen : MonoBehaviour
{ 
    private bool _liftopen;
  [SerializeField] private GameObject liftDoorOpen1; 
  [SerializeField] private GameObject liftDoorOpen2;
  [SerializeField] private  GameObject liftDoorClose1;
  [SerializeField] private GameObject liftDoorClose2;
  [SerializeField] private  GameObject fade;
  [SerializeField] private  AudioSource liftOpening;
  [SerializeField] private string triggerName;
  [SerializeField] private Animator animator;

   private void FixedUpdate()
   {
       if (_liftopen) return;
       animator.SetTrigger(triggerName);
       StartCoroutine(Wait(5));
       _liftopen = true;
   }

   private IEnumerator Wait(float time)
   {
        
       yield return new WaitForSeconds(time);
       liftDoorOpen1.SetActive(true);
       liftDoorOpen2.SetActive(true);
       liftDoorClose1.SetActive(false);
       liftDoorClose2.SetActive(false);
       liftOpening.Play();
       fade.SetActive(false);

   }   
}
