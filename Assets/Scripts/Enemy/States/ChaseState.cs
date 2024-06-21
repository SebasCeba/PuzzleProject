using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class ChaseState : BaseState
    {
        private NavMeshAgent _agent;
        private float _speed;
        private float _stopDistance;

        public ChaseState(EnemyController controller) : base(controller)
        {
            _controller.GetChaseParams(out _agent, out _speed, out _stopDistance);
        }

        public override void EnterState()
        {
            //Debug.Log("enter chase");
            _agent.speed = _speed;
            _agent.SetDestination(_controller.GetPlayerPosition());
        }

        public override void ExitState()
        {
            
        }

        public override void RunState()
        {
            _controller.FacePlayer();
            _agent.SetDestination(_controller.GetPlayerPosition());
            if (_agent.remainingDistance > _stopDistance)
            {
                Move();
            }
            else
            {
                Stop();
            }
        }

        private void Move()
        {
            _agent.isStopped = false;
            _agent.speed = _speed;
        }

        private void Stop()
        {
            _agent.isStopped = true;
            _agent.speed = 0;
        }
    }
}
