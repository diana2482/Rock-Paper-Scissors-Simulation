using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MobSpawner : MonoBehaviour
{
    [FormerlySerializedAs("MobCount")] [SerializeField]
    private int mobCount;

    public List<GameObject> creatures;
    void Start()
    {
        mobCount = PlayerPrefs.GetInt("CreatureCount", 1);
        GameManager.instance.rockCount = mobCount;
        GameManager.instance.paperCount = mobCount;
        GameManager.instance.scissorsCount = mobCount;
        Spawn();
    }

    private void Spawn()
    {
        Vector3 pos1 = new Vector3(2.2f,0,5.4f);
        Vector3 pos2 = new Vector3(-5.3f,0,-2.9f);
        Vector3 pos3 = new Vector3(5.6f,0,-5.3f);
        var positions = new List<Vector3>{pos1,pos2,pos3};
        for (int i = 0; i < mobCount; i++)
        {
            for (int j = 0; j < creatures.Count; j++)
            {
                Instantiate(creatures[j], positions[j] + GetRandomPointInACircle(5.4f), Quaternion.identity);
            }
        }
    }

    private Vector3 GetRandomPointInACircle(float radius)
    {
        return new Vector3(Random.Range(-radius,radius),0,Random.Range(-radius,radius));
    }
}