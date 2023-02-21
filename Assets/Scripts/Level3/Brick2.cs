using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Brick2 : MonoBehaviour
{
    private SpriteRenderer sr;
    public int Hitpoints = 1;
    public ParticleSystem DestroyEffect;
    public static event Action<Brick2> OnBrickDestruction;

    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball2 ball = collision.gameObject.GetComponent<Ball2>();
        ApplyCollision(ball);
    }
    private void ApplyCollision(Ball2 ball)
    {
        Hitpoints--;
        if(Hitpoints <= 0)
        {
            OnBrickDestruction?.Invoke(this);
            OnSpawnItem();
            SpawnDestroyEffect();
            Destroy(this.gameObject);
        }
        else
        {

        }
    }

    private void OnSpawnItem()
    {
        float buffChance = UnityEngine.Random.Range(0, 100f);
        float deBuffChance = UnityEngine.Random.Range(0, 100f);
        bool alreadySpawn = false; 
        if(buffChance  <= CollectableManager.Instance.BuffChance)
        {
            alreadySpawn = true;
            Collectable newBuff = this.SpawnCollectable(true);
        }

        if (deBuffChance <= CollectableManager.Instance.DeBuffChance && !alreadySpawn)
        {
            Collectable newBuff = this.SpawnCollectable(true);
        }
    }

    private Collectable SpawnCollectable(bool isBuff)
    {
        List<Collectable> collectables = new List<Collectable>();
        if (isBuff)
        {
            collectables = CollectableManager.Instance.Buffs;
        }
        else
        {
            collectables = CollectableManager.Instance.DeBuffs;
        }

        int buffIndex = UnityEngine.Random.Range(0, collectables.Count);
        Collectable prefab = collectables[buffIndex];
        Collectable newCollectable = Instantiate(prefab, transform.position, Quaternion.identity);
        return newCollectable;
    }

    private void SpawnDestroyEffect()
    {
        Vector3 brickPos = gameObject.transform.position;
        Vector3 spawnPos = new Vector3(brickPos.x, brickPos.y, brickPos.z - 0.2f);
        GameObject effect = Instantiate(DestroyEffect.gameObject, spawnPos, Quaternion.identity);

        MainModule mainModule = effect.GetComponent<ParticleSystem>().main;
        mainModule.startColor = sr.color;
        Destroy(effect, DestroyEffect.main.startLifetime.constant);
    }
}
