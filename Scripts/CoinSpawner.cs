using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin[] _prefabs;
    [SerializeField] private float _spawnInterval = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCoin), 0f, _spawnInterval);
    }

    private void SpawnCoin()
    {
        int randomIndex = Random.Range(0, _prefabs.Length);
        GameObject coinPrefab = _prefabs[randomIndex].gameObject;
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}
