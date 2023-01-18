using System.Collections.Generic;
using FlockingSimulation.Configs;
using FlockingSimulation.Core;
using UnityEngine;
using VContainer;

namespace FlockingSimulation.Views
{
    [RequireComponent(typeof(Collider2D))]
    public class FlockAgentView : MonoBehaviour
    {
        public int FlockIndex { get; private set; }

        private Collider2D _agentCollider;

        private float _neighborRadius;

        private void Awake()
        {
            _agentCollider = GetComponent<Collider2D>();
        }

        [Inject]
        public void Construct(FlockSettingsConfig flockSettingsConfig)
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
            FlockIndex = flockIndex;
        }

        public void UpdateName(int type, int index)
        {
            gameObject.name = $"{Constants.FlockAgentPrefix}_{Constants.FlockName}{type}_{index}";
        }

        private void RotateTowardsDirection(Vector2 direction)
        {
            transform.up = direction;
        }

        private void MoveTowardsDirection(Vector2 direction)
        {
            transform.position += (Vector3)direction * Time.deltaTime;
        }

        public List<Transform> GetNeighborObjects()
        {
            var context = new List<Transform>();

            Collider2D[] neighborColliders = { };
            
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, _neighborRadius, neighborColliders);

            for (var i = 0; i < size; i++)
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