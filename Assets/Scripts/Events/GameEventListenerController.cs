using UnityEngine;
using UnityEngine.Events;

namespace Afloat.Events
{
    public class GameEventListenerController : MonoBehaviour
    {
        [SerializeField] private GameEvent _event = null;
        [SerializeField] private UnityEvent _response = null;

        public void OnEventRaised()
        {
            _response.Invoke();
        }

        private void OnEnable()
        {
            _event.RegisterListener(this);
        }

        private void OnDisable()
        {
            _event.UnregisterListener(this);
        }
    }
}
