using System;
using TMPro;
using UnityEngine.UI;

namespace ECS.Components
{
    [Serializable]
    public struct UIBuffComponent
    {
        public Image Image;
        public TextMeshProUGUI Description;
    }
}