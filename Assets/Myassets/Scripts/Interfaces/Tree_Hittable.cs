using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Hittable : MonoBehaviour, I_Hittable
{
    [SerializeField] GameObject[] fruits;
    [SerializeField] int maxFruitAmount = 2;
    [SerializeField] float offset = 1f;
    [SerializeField] Sprite sprite;
    
    public void GetHit(int damage)
    {
        SpawnFruit(maxFruitAmount);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    void SpawnFruit(int _maxFruitAmount)
    {
        int i = 0;
        int _randomAmount = Random.Range(1, _maxFruitAmount);
        while (i < _randomAmount)
        {
            int _randomFruit = Random.Range(0, fruits.Length);
            Instantiate(fruits[_randomFruit], CalculateRandomSpawn(transform.position, offset), Quaternion.identity);
            i++;
        }
    }

    Vector3 CalculateRandomSpawn(Vector3 _position, float _offset)
    {
        float _randomX = Random.Range(-_offset, _offset);
        float _randomY = Random.Range(-_offset, _offset);
        _position = new Vector3(_position.x + _randomX, _position.y + _randomY, 0f);
        return _position;
    }
}
