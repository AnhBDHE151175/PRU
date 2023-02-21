using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Level3.Collectables
{
    public class ExtendOrShrink : Collectable
    {
        public float AddWidth = 50f;
        protected override void ApplyEffect()
        {
            if (PaddleManager.Instance != null)
            {       
                PaddleManager.Instance.StartAnimation(AddWidth);
            }
        }
    }
}
