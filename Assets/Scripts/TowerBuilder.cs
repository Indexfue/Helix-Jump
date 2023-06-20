using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private GameObject _beam;

    [SerializeField] private List<Platform> _platforms;
    [SerializeField] private StartPlatform _startingPlatform;
    [SerializeField] private FinishPlatform _finishingPlatform;

    private readonly float _borderPlatformAdditionalScale = 0.5f;
    private readonly float _beamAdditionalScale = 3f;
    private readonly float _spawnRate = 1f;
    
    public float BeamScaleY => _levelCount / 2f + _borderPlatformAdditionalScale + _beamAdditionalScale / 2;
    public float PlatformScaleY => 1 / BeamScaleY;

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(transform.localScale.x, BeamScaleY, transform.localScale.z);

        Vector3 spawnPoint = beam.transform.position;
        spawnPoint.y += beam.transform.localScale.y - _beamAdditionalScale;
        
        SpawnBorderPlatform(_startingPlatform, ref spawnPoint, beam.transform);
        SpawnPlatforms(ref spawnPoint, beam.transform);
        SpawnBorderPlatform(_finishingPlatform, ref spawnPoint, beam.transform);
    }

    private void SpawnPlatforms(ref Vector3 position, Transform parent)
    {
        for (int i = 0; i < _levelCount; i++)
        {
            Platform newPlatform = Instantiate(_platforms[Random.Range(0, _platforms.Count)], 
                        position, 
                  Quaternion.Euler(0, Random.Range(0, 361), 0), 
                        parent);
            position.y -= _spawnRate;
            SetNormalPlatformYAxisScale(newPlatform);
        }
    }

    private void SpawnBorderPlatform(Platform platform, ref Vector3 position, Transform parent)
    {
        Platform newPlatform = Instantiate(platform, position, Quaternion.identity, parent);
        SetNormalPlatformYAxisScale(newPlatform);
        position.y -= _spawnRate;
    }

    private void SetNormalPlatformYAxisScale(Platform platform)
    {
        platform.transform.localScale =
            new Vector3(platform.transform.localScale.x, PlatformScaleY, platform.transform.localScale.z);
    }
}
