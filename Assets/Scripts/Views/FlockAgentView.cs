using System.Collections.Generic;
using Configs;
using Core;
using UnityEngine;
using VContainer;

namespace Views
{
    [RequireComponent(typeof(Collider2D))]
    public class FlockAgentView : MonoBehaviour
    {
        public int FlockIndex => _flockIndex;

        private int _flockIndex;

        private Collider2D _agentCollider;

        private float _neighborRadius;

        private void Awake()
        {
            _agentCollider = GetComponent<Collider2D>();
        }

        [Inject]
        private void InjectNeighborRadius(FlockSettingsConfig flockSettingsConfig)
        {
            _neighborRadius = flockSettingsConfig.NeighborRadius;
        }
    
        public void Move(Vector2 velocity)
        {
            RotateTowardsDirection(velocity);
            MoveTowardsDirection(velocity);
        }

        public void BelongsToFlock(int flockIndex)
        {
            _flockIndex = flockIndex;
        }
    
        public void UpdateName(int type, int index)
        {
            gameObject.name = Constants.FlockAgentPrefix + Constants.FlockName + type + "_" + index;
        }

        private void RotateTowardsDirection(Vector2 direction)
        {
            transform.up = direction;
        }
    
        private void MoveTowardsDirection(Vector2 direction)
        {
            transform.position += (Vector3) direction * Time.deltaTime;
        }
    
        public List<Transform> GetNeighborObjects()
        {
            var context = new List<Transform>();
        
            // ReSharper disable once Unity.PreferNonAllocApi
            var neighborColliders = Physics2D.OverlapCircleAll(transform.position, _neighborRadius);

            for (var i = 0; i < neighborColliders.Length; i++)
            {
                if (_agentCollider == neighborColliders[i])
                {
                    continue;
                }

                context.Add(neighborColliders[i].transform);
            }

            return context;
        }
    }
}
