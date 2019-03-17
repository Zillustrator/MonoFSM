using System.Collections;
using System.ComponentModel;
using UnityEngine;

namespace MonoFSM
{
    public abstract class FiniteState : MonoBehaviour
    {
        [SerializeField] protected FiniteStateMachine FSM;

        [Description("FSM starts the UpdateRoutine between Enter and Exit calls")]
        public abstract IEnumerator UpdateRoutine();
        
        [Description("FSM calls Enter immediately before starting the UpdateRoutine")]
        public abstract void Enter();
        
        [Description("FSM calls Exit immediately after comleting the UpdateRoutine")]
        public abstract void Exit();
    }
}