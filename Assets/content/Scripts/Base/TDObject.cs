using UnityEngine;

namespace MaximovInk
{
    [ExecuteInEditMode]
    public class TDObject : MonoBehaviour
    {

        public bool sortInUpdate = true;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + new Vector3(-1, 0, 0), transform.position + new Vector3(1, 0, 0));
        }

        private void LateUpdate()
        {
            if (!sortInUpdate)
                return;

            Sort();
        }

        public void Sort()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        }
    }
}