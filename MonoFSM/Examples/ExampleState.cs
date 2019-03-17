using System.Collections;
using UnityEngine;

namespace MonoFSM.States
{
    public class ExampleState : FiniteState
    {
        [Header("Transition to the Exit State when the Input Key is hit")]
        [SerializeField] private KeyCode _inputKey = KeyCode.Space;
        [SerializeField] private FiniteState _exitState;
    
        private IEnumerator update()
        {
            while (FSM.NextState == null)
            {
                yield return null;
            
                if (Input.GetKeyDown(_inputKey))
                {	
                    FSM.NextState = _exitState;
                }
            }
        }

        public override IEnumerator UpdateRoutine()
        {
            return update();
        }

        public override void Enter()
        {
            Debug.LogFormat("{0}:Enter", typeof(ExampleState));
        }

        public override void Exit()
        {
            Debug.LogFormat("{0}:Exit", typeof(ExampleState));
        }
    }
}
