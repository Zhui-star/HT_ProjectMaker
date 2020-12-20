using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTLibrary.Application
{
    /// <summary>
    /// 简单的单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MonoSingleton<T>: MonoBehaviour where T:MonoBehaviour
    {

        private static T instance;

        public static T Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = FindObjectOfType<T>();

                    if(!instance)
                    {
                        var instanceName = typeof(T).Name;

                        var instanceObj = GameObject.Find(instanceName);

                        if (!instanceObj)
                        {
                            instanceObj = new GameObject();
                            instanceObj.name = instanceName;
                        }

                         instanceObj.AddComponent<T>();                   
                    }
                }
                return instance;
            }
        }
    }

}
