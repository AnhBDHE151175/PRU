using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Level3.Collectables
{
    public class MutiBall : Collectable
    {
        protected override void ApplyEffect()
        {    
            foreach(Ball2 ball in BallManager.Instance.Balls.ToList())
            {
                BallManager.Instance.SpawnBalls(ball.gameObject.transform.position, 2);
            }
        }
    }
}
