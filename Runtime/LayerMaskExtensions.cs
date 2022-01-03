using JetBrains.Annotations;
using UnityEngine;


// ReSharper disable once UnusedType.Global
// ReSharper disable MemberCanBeInternal


namespace UniEnt.UnityQOL.Runtime {


    public static class LayerMaskExtensions {


        public static bool IsInLayerMasks([NotNull] this GameObject gameObject, int layerMasks) => layerMasks == (layerMasks | (1 << gameObject.layer));


    }


}
