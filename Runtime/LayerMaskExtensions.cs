using JetBrains.Annotations;
using UnityEngine;


// ReSharper disable once UnusedType.Global
// ReSharper disable MemberCanBeInternal


namespace UniEnt.Unity_QOL.Runtime {


    public static class LayerMaskExtensions {


        // ReSharper disable once UnusedMember.Global
        public static bool IsInLayerMasks([NotNull] this GameObject gameObject, int layerMasks) => layerMasks == (layerMasks | (1 << gameObject.layer));


    }


}
