using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HTLibrary.Application
{
    public class AutoHide : MonoBehaviour
    {
        private void OnEnable()
        {
            Invoke("Hide", 2.0f);
        }

        void Hide()
        {
            this.gameObject.SetActive(false);
        }
    }


}
