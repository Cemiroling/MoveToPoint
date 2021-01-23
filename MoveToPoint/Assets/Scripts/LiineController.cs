using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiineController : MonoBehaviour
{
    private LineRenderer _renderer;

    [SerializeField] Texture[] _textures;

    private int _animStep;
    private float _fps = 60f;
    private float _fpsCounter;


    private void Awake()
    {
        _renderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        _fpsCounter += Time.deltaTime;

        if(_fpsCounter >= 1 / _fps)
        {
            _animStep++;
            if (_animStep == _textures.Length)
                _animStep = 0;

            _renderer.material.SetTexture("_MainTex", _textures[_animStep]);

            _fpsCounter = 0;
        }
    }
}
