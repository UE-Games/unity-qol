using UnityEngine;


namespace UniEnt.Unity_QOL.Runtime {


    // ReSharper disable once ClassCanBeSealed.Global
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {


        // Check to see if we're about to be destroyed.
        // ReSharper disable once StaticMemberInGenericType
        static readonly object SLock = new();
        static T _sInstance;


        // ReSharper disable once MemberCanBeInternal
        /// <summary>
        ///     Access singleton instance through this property.
        /// </summary>
        /// <remarks>This instance will persist across scene changes.</remarks>
        public static T Instance {
            get {
                lock (SLock) {
                    if (_sInstance != null)
                        return _sInstance;

                    CreateInstance(out GameObject singletonObject);

                    // Make instance persistent.
                    DontDestroyOnLoad(singletonObject);

                    return _sInstance;
                }
            }
        }


        // ReSharper disable once MemberCanBeInternal
        /// <summary>
        ///     Access non persistent singleton instance through this property.
        /// </summary>
        /// <remarks>This instance will not persist across scene changes.</remarks>
        public static T NonPersistentInstance {
            get {
                lock (SLock)
                    return _sInstance != null ? _sInstance : CreateInstance(out GameObject _);
            }
        }


        void OnDestroy() {
            lock (SLock)
                _sInstance = null;
        }


        /// <summary>
        ///     Create a singleton instance and attach to a dedicated GameObject.
        /// </summary>
        static T CreateInstance(out GameObject singletonObject) {
            lock (SLock) {
                // Search for existing instance.
                _sInstance = (T)FindObjectOfType(typeof(T));

                // Use existing instance or create a new one if it doesn't already exist.
                if (_sInstance != null) {
                    singletonObject = _sInstance.gameObject;

                    return _sInstance;
                }

                // Create a new GameObject and attach the singleton to it.
                singletonObject = new GameObject {
                    name = typeof(T) + " (Singleton)"
                };

                _sInstance = singletonObject.AddComponent<T>();

                return _sInstance;
            }
        }


    }


}
