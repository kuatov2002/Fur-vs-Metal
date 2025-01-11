using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

}

[System.Serializable]
public class Waves
{
    [SerializeField] private WaveSettings[] _waveSettings;
}

[System.Serializable]
public class WaveSettings
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _neededSpawner;
    [SerializeField] private float _spawnDelay;
}
