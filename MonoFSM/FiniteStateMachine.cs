using System.Collections;
using UnityEngine;

namespace MonoFSM
{
    public class FiniteStateMachine : MonoBehaviour
    {
        [SerializeField] private FiniteState _startState;
        
        private FiniteState _currState;
        private FiniteState _nextState;

        private void Start()
        {
            if (_startState)
            {
                NextState = _startState;
            }
        }

        public FiniteState NextState
        {
            set
            {
                if (!_currState)
                {
                    _currState = value;

                    StartCoroutine(FSM());
                }
                else
                {
                    _nextState = value;
                }
            }
            get
            {
                return _nextState;
            }
        }

        private IEnumerator FSM()
        {
            while (_currState)
            {
                _currState.Enter();
                
                yield return StartCoroutine(_currState.UpdateRoutine());
                
                _currState.Exit();
			
                _currState = _nextState;
                
                _nextState = null;
            }
        }
    }
}
