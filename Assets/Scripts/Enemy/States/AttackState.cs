using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class AttackState : BaseState
    {
        private NavMeshAgent _agent;
        private float _stopDistance;
        private Weapon _weapon;

        public AttackState(EnemyController controller) : base(controller)
        {
            _controller.GetAttackParams(out _agent, out _stopDistance, out _weapon);
        }

        public override void EnterState()
        {
            //Debug.Log("enter attack");
            _agent.isStopped = true;
            _agent.speed = 0;
        }

        public override void ExitState()
        {
            _weapon.DisableAttack();
            _weapon.BackToIdle();
        }

        public override void RunState()
        {
            _controller.FacePlayer();
            _agent.SetDestination(_controller.GetPlayerPosition());
            if (_agent.remainingDistance <= _stopDistance)
            {
                _weapon.Attack();
            }
        }
    }
}