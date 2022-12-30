using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class EnemySpawnSequence : ScriptableObject
{
    [SerializeField]
    private EnemyFactory _factory;

    [SerializeField]
    private EnemyType _type = EnemyType.Ellen;

    [SerializeField, Range(1, 100)]
    private int _amount = 1;

    [SerializeField, Range(0.1f, 10f)]
    private float _coolDown = 1f;

    public State Begin() => new State(this);

    [Serializable]
    public struct State
    {
        private EnemySpawnSequence _sequence;
        private int _count;
        private float _coolDown;

        public State(EnemySpawnSequence sequence)
        {
            _sequence = sequence;
            _count = 0;
            _coolDown = _sequence._coolDown;
        }

        public float Progress(float deltaTime)
        {
            _coolDown += deltaTime;
            while(_coolDown >= _sequence._coolDown)
            {
                _coolDown -= _sequence._coolDown;
                if(_count >= _sequence._amount)
                {
                    return _coolDown;
                }

                _count++;
                QuickGame.SpawnEnemy(_sequence._factory, _sequence._type);
            }

            return -1f;
        }
    }
}

