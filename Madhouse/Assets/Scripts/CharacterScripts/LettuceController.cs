using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LettuceController : EnemyController
{
    //public GameObject particle;
    //public GameObject drop;
        
   // public ParticleSystem particles;

    //AudioSource audioData;
    Animator animator;

    public override void StartMod()
    {
        throw new System.NotImplementedException();
    }
    public override void AttackMod()
    {
        throw new System.NotImplementedException();
    }
    public override void HitMod()
    {
        throw new System.NotImplementedException();
    }
    public override void StopAttackMod()
    {
        throw new System.NotImplementedException();
    }
    public override void UpdateMod()
    {
        throw new System.NotImplementedException();
    }

    public override void SpawnParticles() {
         float randomX = Random.Range(-45f, -80f);
         float randomY = Random.Range(0f, 360f);
         GameObject dropInstance = Instantiate(drop, gameObject.transform.position, Quaternion.Euler(0, 0, 0));

         dropInstance.GetComponent<Rigidbody>().AddForce(Random.Range(-5, 5), Random.Range(0, 5), Random.Range(-5, 5), ForceMode.Impulse);

         particle.transform.rotation = Quaternion.Euler(randomX, randomY, 0);

         particles.Play();
    }
}
