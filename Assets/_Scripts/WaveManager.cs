using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public static WaveManager SharedInstance;
    private List<WaveSpawner> waves;
    public UnityEvent onWaveChanged;
    public int WavesCount
    {
        get => waves.Count;
    }

    private void Awake()
    {
        #region Singleton
        if (SharedInstance == null)
        {
            SharedInstance = this;
            waves = new List<WaveSpawner>();
        }
        else
        {
            Debug.Log("Manager duplicado debe ser destruido", gameObject);
            Destroy(gameObject);
        }
        #endregion
    }

    public void AddWave(WaveSpawner wave)
    {
        waves.Add(wave);
        onWaveChanged.Invoke();
    }

    public void RemoveWave(WaveSpawner wave)
    {
        waves.Remove(wave);
        onWaveChanged.Invoke();
    }
}
