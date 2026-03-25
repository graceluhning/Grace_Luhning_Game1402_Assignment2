using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
   [SerializeField] private Transform spawnPoint;
   [SerializeField] private GameObject balloon;
   [SerializeField] private float respawnTime = 2f;

   public bool spawned = false;

   void Start()
   {
      Spawn();
   }
   
   void Spawn() // balloon spawn logic
   {
      if (!spawned && spawnPoint != null && balloon != null)
      {
         GameObject newBalloon = Instantiate(balloon, spawnPoint.position, Quaternion.identity); // create a new balloon
         newBalloon.GetComponent<Balloon>().SetSpawner(this); // what is the new balloon?
         
         spawned = true; // set spawned true so no other balloon spawns
         Debug.Log("spawned!");
         
      }

   }

   public void OnBalloonDestroyed() 
   {
      Debug.Log("BalloonDestroyed");
      spawned = false; // set spawned false so another balloon can spawn
      Invoke(nameof(Spawn), respawnTime);
   }
}

