using System.Collections.Generic;

namespace  MarsRover.Domain
{
    public class Movement
    {
        public static Dictionary<MovementEnum, int> Movements = new Dictionary<MovementEnum, int>()
        {
            { MovementEnum.Forward, 1 },
            { MovementEnum.Backward, -1 },
            { MovementEnum.Left, 1 },
            { MovementEnum.Right, 1 }       
        };  
    }
}