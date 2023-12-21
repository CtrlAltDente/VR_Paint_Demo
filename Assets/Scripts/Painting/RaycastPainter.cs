using Es.InkPainter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace VR_Paint_Demo.Painting
{
    public class RaycastPainter : MonoBehaviour
    {
        [SerializeField]
        private Brush _brush;

        [SerializeField]
        private InputActionReference _drawAction;

        private bool _isDraw;

        private void Start()
        {
            _drawAction.action.performed += action => _isDraw = true;

            _drawAction.action.canceled += action => _isDraw = false;
        }

        private void Update()
        {
            if(_isDraw)
            {
                Draw();
            }
        }

        public void Draw()
        {
            Debug.Log("Start drawing");

            RaycastHit hit;

            if(Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log($"{hit.transform.gameObject.name}");

                var paintObject = hit.transform.GetComponent<InkCanvas>();

                if (paintObject != null)
                    paintObject.Paint(_brush, hit);

                Debug.Log("Drawed on object");
            }
        }
    }
}